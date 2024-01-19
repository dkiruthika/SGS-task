using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Models;

namespace UserApi.Service
{
    public class UserService : IUserService
    {
        private readonly IAppDbContext appDbContext;
        private readonly IPasswordHasher _passwordHasher;
        public UserService(IAppDbContext appDbContext, IPasswordHasher passwordHasher)
        {
            this.appDbContext = appDbContext;
            _passwordHasher = passwordHasher;
        }
        public string AddUserDb(User user)
        {
            var validationResult = ValidateUser(user);
            if (validationResult.Equals("Valid user"))
            {
                user.Password = _passwordHasher.Hash(user.Password);
                appDbContext.Users.Add(user);
                appDbContext.SaveChanges();
                return "User Added";
            }
            return validationResult;
        }
        public User GetUserDb(int id)
        {
            var user = appDbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public bool UpdateUserDb(int id)
        {
            var user = appDbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                user.IsActive = false;
                appDbContext.SaveChanges();

                var Users = appDbContext.Users.ToList();
                return true;
            }
            return false;
        }
        public User UpdateUserDb(int userid, string username, bool userstatus)
        {
            var user = appDbContext.Users.FirstOrDefault(x => x.Id == userid);
            if (user != null)
            {
                user.IsActive = userstatus;
                user.Name = username;
                appDbContext.SaveChanges();
                return user;

            }
            return null;
        }
        public List<User> GetUsersDb()
        {
            return appDbContext.Users.ToList();
        }
        private string ValidateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return "User field is null";
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(user.Email);
                if (addr.Address == user.Email)
                {
                    return "Valid user";
                }
                else
                {
                    return "Invalid user";
                }
            }
            catch (Exception e)
            {
                return "Invalid email format";
            }


        }

    }
}
