
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Text;
using UserApi.Controllers;
using UserApi.Models;
using UserApi.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LoginUnitTest
{
    public class LoginTest
    {
        Mock<ILoginService> _loginMockService;
        public LoginTest()
        {
            _loginMockService = new Mock<ILoginService>();
        }
        
        [Fact]
        public void LoginFails_ByEmptyField()
        {
            UserLogin user = new UserLogin()
            {
                emailid = "",
                password = ""
            };
            _loginMockService.Setup(x =>x.LoginDb(user.emailid,user.password)).Returns("User field is empty");
            var loginController=new LoginController(_loginMockService.Object);
            var errorResult = loginController.Login(user);
            Assert.IsType<BadRequestObjectResult>(errorResult);
            var data = errorResult as BadRequestObjectResult;
            Assert.Equal("User field is empty", data.Value);
        }
        [Fact]
        public void LoginFails_ByInvalidEmailFormat()
        {
            UserLogin user = new UserLogin()
            {
                emailid = "brin123.com",
                password = "test123"
            };
            _loginMockService.Setup(x => x.LoginDb(user.emailid, user.password)).Returns("Invalid email format");
            var loginController = new LoginController(_loginMockService.Object);
            var errorResult = loginController.Login(user);
            Assert.IsType<BadRequestObjectResult>(errorResult);
            var data = errorResult as BadRequestObjectResult;
            Assert.Equal("Invalid email format", data.Value);
        }
        [Fact]
        public void LogicFails_ByIncorrectCredentials()
        {
            UserLogin user = new UserLogin()
            {
                emailid = "kas123@gmail.com",
                password = "password"
            };
            _loginMockService.Setup(x => x.LoginDb(user.emailid, user.password)).Returns("Invalid Username or Password");
            var loginController = new LoginController(_loginMockService.Object);
            var errorResult = loginController.Login(user);
            Assert.IsType<BadRequestObjectResult>(errorResult);
            var data = errorResult as BadRequestObjectResult;
            Assert.Equal("Invalid Username or Password", data.Value);
        }
        [Fact]
        public void LoginSuccess() 
        {
            UserLogin user = new UserLogin()
            {
                emailid= "kas123@gmail.com",
                password= "acb@123"
            };
            _loginMockService.Setup(x => x.LoginDb(user.emailid, user.password)).Returns("Login Success");
            var loginController = new LoginController(_loginMockService.Object);
            var errorResult = loginController.Login(user);
            Assert.IsType<OkObjectResult>(errorResult);
            var data=errorResult as OkObjectResult;
            Assert.Equal("Login Success", data.Value);
        }
    }
}