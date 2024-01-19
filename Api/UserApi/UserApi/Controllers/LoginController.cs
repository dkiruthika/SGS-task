using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using UserApi.Data;
using UserApi.Models;
using UserApi.Service;

namespace UserApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            this._loginService = loginService;  
        }
        
        [HttpPost]
        public ActionResult Login(UserLogin user)
        {
            
            string loginResult = _loginService.LoginDb(user.emailid, user.password);

            if (loginResult == "Login Success")
            {
                return Ok(true);
            }
            return BadRequest(loginResult);

            
        }

    }
}
