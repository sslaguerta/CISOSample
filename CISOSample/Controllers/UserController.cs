using CISOSample.Interface;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CISOSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region fields
        private readonly IUserService _userService;
        #endregion

        #region Constructors
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region GetUers
        [HttpGet]
        public IActionResult GetUsers()
        {
            var result = _userService.GetUsers();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetApprovedUsers()
        {
            var result = _userService.GetApprovedUsers();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetForConsiderationUsers()
        {
            var result = _userService.GetForConsiderationUsers();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetRejectedUsers()
        {
            var result = _userService.GetRejectedUsers();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult ViewUser(int id)
        {
            var result = _userService.ViewUser(id);
            return Ok(result);
        }
        #endregion

        [HttpPut("{id}")]
        public IActionResult ChangeStatus(int id, string command)
        {
            var result = _userService.ChangeStatus(command, id);

            if (!result)
            {
                return BadRequest(new { message = "Invalid Request Please try again" });
            }
            return Ok(new { message = $"User status succesfully changed to '{command}'" });
        }
    }
}
