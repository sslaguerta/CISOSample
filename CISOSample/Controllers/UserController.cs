using CISOSample.Interface;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CISOSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

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
    }
}
