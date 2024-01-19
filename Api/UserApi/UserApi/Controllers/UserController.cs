
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Models;
using UserApi.Service;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService,ILogger<UserController> logger)
        {
            this._userService = userService;
            this._logger = logger;
        }
        
        [HttpPost]
        [Route("Add User")]
        public ActionResult AddUser(User user)
        {
            _logger.LogInformation("UserController starts executing");
            if(user == null)
            {
                return BadRequest("User object is null");
            }
            
            var result = _userService.AddUserDb(user);
            if (result.Equals("User Added"))
            {
                    return Ok("User Added Successfully");
            }
            
            return BadRequest(result);
        }
        [HttpGet("{id:int}")]
        public ActionResult GetUser(int id)
        {
            var user=_userService.GetUserDb(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("delete")]
        public ActionResult DeleteUser(int id)
        {
            var flag = _userService.UpdateUserDb(id);
            if (flag)
            { 
                return Ok("Deleted");
            }
            return BadRequest("Id not found");
        }
        [HttpPut]
        public ActionResult UpdateUser(int userid,string username,bool userstatus)
        {
            var user=_userService.UpdateUserDb(userid,username,userstatus);
            if (user != null)
            {
                return Ok(user);

            }
            return BadRequest("User not found");
        }
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            List<User> employees = _userService.GetUsersDb();
            return employees;
            
        }
        

    }
}
