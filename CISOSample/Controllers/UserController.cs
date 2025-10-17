using CISOSample.Models;
using CISOSample.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CISOSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private List<User> GetSampleUsers()
        {
            return new List<User>
            {
                new User { Id = 1, Name = "Syrill Dex Laguerta", Email = "sslaguerta@sscgi.com", Status = null},
                new User { Id = 2, Name = "Ramyr Christopher Garciniego", Email = "rlgarciniego@sscgi.com", Status = null},
                new User { Id = 3, Name = "Cherwin John Rabang", Email = "cerabang@sscgi.com", Status = null},
                new User { Id = 4, Name = "Lorenz Jedd Alvarez", Email = "ljalvarez@sscgi.com", Status = null},
            };
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = GetSampleUsers().Where(x => x.Status == null);

            var viewModel = users.Select(user => new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                ContactNumber = user.ContactNumber,
                Description = user.Description,
                Status = user.Status,
            }).ToList();
            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public IActionResult ViewUser(int id)
        {
            var result = GetSampleUsers();
            var user = result.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound(new { mesage = "user not found" });

            var viewModel = new UserViewModel
            {
                Id = user.Id,
                Name = user?.Name,
                Email = user?.Email,
                ContactNumber = user?.ContactNumber,
                Description = user?.Description,
                Status = user?.Status,
            };

            return Ok(viewModel);
        }
    }
}
