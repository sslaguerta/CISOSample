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
        #region Users
        private List<User> GetSampleUsers()
        {
            return new List<User>
            {
                new User { Id = 1, Name = "Syrill Dex Laguerta", Email = "sslaguerta@sscgi.com", Status = Status.Approved},
                new User { Id = 2, Name = "Ramyr Christopher Garciniego", Email = "rlgarciniego@sscgi.com", Status = null},
                new User { Id = 3, Name = "Cherwin John Rabang", Email = "cerabang@sscgi.com", Status = Status.ForConsideration},
                new User { Id = 4, Name = "Lorenz Jedd Alvarez", Email = "ljalvarez@sscgi.com", Status = Status.Rejected},
                new User { Id = 5, Name = "Justine Rae Villanueva", Email = "jrvillanueva@sscgi.com", Status = Status.Approved },
                new User { Id = 6, Name = "Kimberly Anne Santos", Email = "kasantos@sscgi.com", Status = Status.ForConsideration },
                new User { Id = 7, Name = "Mark Angelo Dela Cruz", Email = "madelacruz@sscgi.com", Status = Status.Rejected },
                new User { Id = 8, Name = "Rafael Jose Mendoza", Email = "rjmendoza@sscgi.com", Status = Status.Approved },
                new User { Id = 9, Name = "Patricia Mae Reyes", Email = "pmreyes@sscgi.com", Status = null },
                new User { Id = 10, Name = "Gian Carlo Bautista", Email = "gcbautista@sscgi.com", Status = Status.ForConsideration },
                new User { Id = 11, Name = "Louise Andrea Navarro", Email = "lanavarro@sscgi.com", Status = Status.Rejected },
                new User { Id = 12, Name = "Jerome Paul Gutierrez", Email = "jpgutierrez@sscgi.com", Status = Status.Approved },
                new User { Id = 13, Name = "Faye Denise Ramos", Email = "fdramos@sscgi.com", Status = null },
                new User { Id = 14, Name = "Kevin Lloyd Manalo", Email = "klmanalo@sscgi.com", Status = Status.ForConsideration },
                new User { Id = 15, Name = "Andrea Nicole Cruz", Email = "ancruz@sscgi.com", Status = Status.Rejected },
                new User { Id = 16, Name = "John Michael Santos", Email = "jmsantos@sscgi.com", Status = Status.ForConsideration },
                new User { Id = 17, Name = "Christine Joy Ramirez", Email = "cjramirez@sscgi.com", Status = Status.Rejected },
                new User { Id = 18, Name = "Allan Benedict Cruz", Email = "abcruz@sscgi.com", Status = Status.Approved },
                new User { Id = 19, Name = "Mae Florentina Dizon", Email = "mfdizon@sscgi.com", Status = null },
                new User { Id = 20, Name = "Joshua Ivan De Leon", Email = "jideleon@sscgi.com", Status = Status.ForConsideration },
                new User { Id = 21, Name = "Leah Rose Castillo", Email = "lrcastillo@sscgi.com", Status = Status.Approved },
                new User { Id = 22, Name = "Paul Andrew Vergara", Email = "pavergara@sscgi.com", Status = Status.Rejected },
                new User { Id = 23, Name = "Mikaela Joyce Navarro", Email = "mjnavarro@sscgi.com", Status = null },
                new User { Id = 24, Name = "Renato Joseph Ramos", Email = "rjramos@sscgi.com", Status = Status.Approved },
                new User { Id = 25, Name = "Janine May Bautista", Email = "jmbautista@sscgi.com", Status = Status.ForConsideration },
                new User { Id = 26, Name = "Cris Anthony Lim", Email = "calim@sscgi.com", Status = Status.Rejected },
                new User { Id = 27, Name = "Hannah Grace Lopez", Email = "hglopez@sscgi.com", Status = Status.Approved },
                new User { Id = 28, Name = "Rico Paolo Tan", Email = "rptan@sscgi.com", Status = Status.ForConsideration },
                new User { Id = 29, Name = "Shaira Mae Gutierrez", Email = "smgutierrez@sscgi.com", Status = null },
                new User { Id = 30, Name = "Daniel James Morales", Email = "djmorales@sscgi.com", Status = Status.Rejected },


            };
        }
        #endregion

        #region GetUers
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

        [HttpGet]
        public IActionResult GetApprovedUsers()
        {
            var users = GetSampleUsers().Where(x => x.Status == Status.Approved);

            var viewModel = users.Select(user => new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Status = user.Status,
                ContactNumber = user.ContactNumber,
                Description = user.Description,
            }).ToList();

            return Ok(viewModel);
        }

        [HttpGet]
        public IActionResult GetForConsiderationUsers()
        {
            var users = GetSampleUsers().Where(x => x.Status == Status.ForConsideration);

            var viewModel = users.Select(user => new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Status = user.Status,
                ContactNumber = user.ContactNumber,
                Description = user.Description,
            }).ToList();

            return Ok(viewModel);
        }

        [HttpGet]
        public IActionResult GetRejectedUsers()
        {
            var users = GetSampleUsers().Where(x => x.Status == Status.Rejected);

            var viewModel = users.Select(user => new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Status = user.Status,
                ContactNumber = user.ContactNumber,
                Description = user.Description,
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
        #endregion
    }
}
