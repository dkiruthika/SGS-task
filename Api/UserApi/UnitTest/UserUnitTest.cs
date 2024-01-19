using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;
using UserApi.Models;
using Moq;
using UserApi.Service;
namespace UnitTest
{
    public class UserUnitTest
    {
        Mock<IUserService> _userServiceMock;


        public UserUnitTest()
        {
          _userServiceMock = new Mock<IUserService>();
        }
        [Fact]
        public void GetByIdSuccess()
        {
            var id = 4;
            var user = new User()
            {
                Id=4,
                Name="kiruthika",
                Email="abc@gmail.com",
                Password="Test",
                IsActive=true
            };
            _userServiceMock.Setup(x=>x.GetUserDb(id)).Returns(user);
            var userController = new UserController(_userServiceMock.Object);
            var successResult = userController.GetUser(id);
            var successModel = successResult as OkObjectResult;
            var fetchUser = successModel?.Value as User;
            Assert.IsType<OkObjectResult>(successResult);
            
        }
        [Fact]
        public void GetByIdFail_ByInvalidId()
        {
            var id = 99999999;
            _userServiceMock.Setup(x => x.GetUserDb(id)).Returns((User)null);
            var userController = new UserController(_userServiceMock.Object);
            var errorResult = userController.GetUser(id);
            Assert.IsType<NotFoundResult>(errorResult);
        }
        
        [Fact]
        public void AddUserSuccess()
        {
            User user = new User()
            {
                Id = 4,
                Name = "Brin",
                Email="brin2312@gmail.com",
                Password="123456"
            };
            List<User> users = new List<User>();
            _userServiceMock.Setup(x => x.AddUserDb(user)).Returns("User Added");
            var userController = new UserController(_userServiceMock.Object);
            var successResult=userController.AddUser(user);
            Assert.IsType<OkObjectResult>(successResult);
        }
        [Fact]
        public void AddUserFail_Empty()
        {
            User user =new User()
            {
                Id=1,
                Name="",
                Email = "brin2312@gmail.com",
                Password = "1235"
            };
            _userServiceMock.Setup(x => x.AddUserDb(user)).Returns("User field is null");
            var userController = new UserController(_userServiceMock.Object);
            var errorResult = userController.AddUser(user);
            Assert.IsType<BadRequestObjectResult>(errorResult);
            var badRequestObjectResult = errorResult as BadRequestObjectResult;
            Assert.Equal("User field is null", badRequestObjectResult.Value);
        }

        [Fact]
        public void AddUserFail_InvalidEmail()
        {
            User user = new User()
            {
                Id = 1,
                Name = "asd",
                Email = "brin2312.com",
                Password = "1235"
            };
            _userServiceMock.Setup(x => x.AddUserDb(user)).Returns("Invalid email format");
            var userController = new UserController(_userServiceMock.Object);
            var errorResult = userController.AddUser(user);
            Assert.IsType<BadRequestObjectResult>(errorResult);
            var badRequestObjectResult = errorResult as BadRequestObjectResult;
            Assert.Equal("Invalid email format", badRequestObjectResult.Value);
        }

        [Fact]
        public void DeleteUserSuccess()
        {
            int validID = 4;
            _userServiceMock.Setup(x => x.UpdateUserDb(validID)).Returns(true);
            var userController = new UserController(_userServiceMock.Object);
            var successResult = userController.DeleteUser(validID);
            Assert.IsType<OkObjectResult>(successResult);
        }
        [Fact]
        public void DeleteUserFail()
        {
            int invalidID = 999999;
            _userServiceMock.Setup(x => x.UpdateUserDb(invalidID)).Returns(false);
            var userController = new UserController(_userServiceMock.Object);
            var errorResult = userController.DeleteUser(invalidID);
            Assert.IsType<BadRequestObjectResult>(errorResult);
        }
        [Fact]
        public void UpdateUserFail()
        {
            int id = 9999;
            string name = "test";
            bool status = false;
            var user = (User)null;
            _userServiceMock.Setup(x => x.UpdateUserDb(id, name, status)).Returns(user);
            var userController = new UserController(_userServiceMock.Object);
            var errorResult = userController.UpdateUser(id, name, status);
            Assert.IsType<BadRequestObjectResult>(errorResult);   
        }
        [Fact]
        public void UpdateUserSuccess()
        {
            int id = 4;
            string name = "test";
            bool status = false;
            var user = new User()
            {
                Id = 4,
                Name = "test",
                Email = "xyz123@gmail.com",
                Password = "string",
                IsActive = false
            };
            _userServiceMock.Setup(x => x.UpdateUserDb(id, name, status)).Returns(user);
            var userController = new UserController(_userServiceMock.Object);
            var successResult = userController.UpdateUser(id, name, status);
            Assert.IsType<OkObjectResult>(successResult);
        }
    }
}