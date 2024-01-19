using Microsoft.AspNetCore.Mvc;
using UserApi.Models;

namespace UserApi.Service
{
    public interface IUserService
    {
        public string AddUserDb(User user);
        public User GetUserDb(int id);
        public bool UpdateUserDb(int id);
        public User UpdateUserDb(int userid, string username, bool userstatus);
        public List<User> GetUsersDb();

    }
}
