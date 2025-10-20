using CISOSample.Data;
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
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }


        #region Users
        private List<User> GetSampleUsers()
        {
            return new List<User>();
            //{
            //    new User { Id = 1, Name = "Syrill Dex Laguerta", Email = "sslaguerta@sscgi.com", Status = Status.Approved, ContactNumber = "09171234567", Description = "Lead programmer with a passion for full-stack development." },
            //    new User { Id = 2, Name = "Ramyr Christopher Garciniego", Email = "rlgarciniego@sscgi.com", Status = null, ContactNumber = "09284561234", Description = "Junior developer exploring cloud integration and DevOps." },
            //    new User { Id = 3, Name = "Cherwin John Rabang", Email = "cerabang@sscgi.com", Status = Status.ForConsideration, ContactNumber = "09985673412", Description = "Frontend developer with strong UI/UX experience." },
            //    new User { Id = 4, Name = "Lorenz Jedd Alvarez", Email = "ljalvarez@sscgi.com", Status = Status.Rejected, ContactNumber = "09183451267", Description = "Data analyst interested in predictive modeling." },
            //    new User { Id = 5, Name = "Justine Rae Villanueva", Email = "jrvillanueva@sscgi.com", Status = Status.Approved, ContactNumber = "09357894561", Description = "HR specialist with a focus on employee engagement." },
            //    new User { Id = 6, Name = "Kimberly Anne Santos", Email = "kasantos@sscgi.com", Status = Status.ForConsideration, ContactNumber = "09276458913", Description = "Backend developer skilled in database management." },
            //    new User { Id = 7, Name = "Mark Angelo Dela Cruz", Email = "madelacruz@sscgi.com", Status = Status.Rejected, ContactNumber = "09451239876", Description = "Marketing coordinator passionate about digital campaigns." },
            //    new User { Id = 8, Name = "Rafael Jose Mendoza", Email = "rjmendoza@sscgi.com", Status = Status.Approved, ContactNumber = "09179864532", Description = "Software tester ensuring quality and reliability in releases." },
            //    new User { Id = 9, Name = "Patricia Mae Reyes", Email = "pmreyes@sscgi.com", Status = null, ContactNumber = "09067891234", Description = "Creative designer with expertise in brand identity." },
            //    new User { Id = 10, Name = "Gian Carlo Bautista", Email = "gcbautista@sscgi.com", Status = Status.ForConsideration, ContactNumber = "09364571289", Description = "System analyst focused on business process improvement." },
            //    new User { Id = 11, Name = "Louise Andrea Navarro", Email = "lanavarro@sscgi.com", Status = Status.Rejected, ContactNumber = "09981236745", Description = "Content writer with background in corporate communications." },
            //    new User { Id = 12, Name = "Jerome Paul Gutierrez", Email = "jpgutierrez@sscgi.com", Status = Status.Approved, ContactNumber = "09162347895", Description = "IT support specialist providing technical assistance to staff." },
            //    new User { Id = 13, Name = "Faye Denise Ramos", Email = "fdramos@sscgi.com", Status = null, ContactNumber = "09283456712", Description = "Administrative officer handling internal documentation." },
            //    new User { Id = 14, Name = "Kevin Lloyd Manalo", Email = "klmanalo@sscgi.com", Status = Status.ForConsideration, ContactNumber = "09457812693", Description = "Backend engineer developing API-driven solutions." },
            //    new User { Id = 15, Name = "Andrea Nicole Cruz", Email = "ancruz@sscgi.com", Status = Status.Rejected, ContactNumber = "09071238965", Description = "Finance assistant experienced in payroll and accounting systems." },
            //    new User { Id = 16, Name = "John Michael Santos", Email = "jmsantos@sscgi.com", Status = Status.ForConsideration, ContactNumber = "09184562379", Description = "Junior developer learning microservices architecture." },
            //    new User { Id = 17, Name = "Christine Joy Ramirez", Email = "cjramirez@sscgi.com", Status = Status.Rejected, ContactNumber = "09276548912", Description = "Recruitment specialist focused on tech hiring." },
            //    new User { Id = 18, Name = "Allan Benedict Cruz", Email = "abcruz@sscgi.com", Status = Status.Approved, ContactNumber = "09345678129", Description = "Senior engineer overseeing backend infrastructure." },
            //    new User { Id = 19, Name = "Mae Florentina Dizon", Email = "mfdizon@sscgi.com", Status = null, ContactNumber = "09198673452", Description = "Executive assistant managing meeting schedules and reports." },
            //    new User { Id = 20, Name = "Joshua Ivan De Leon", Email = "jideleon@sscgi.com", Status = Status.ForConsideration, ContactNumber = "09984562311", Description = "Database administrator maintaining secure data systems." },
            //    new User { Id = 21, Name = "Leah Rose Castillo", Email = "lrcastillo@sscgi.com", Status = Status.Approved, ContactNumber = "09165498732", Description = "Project coordinator ensuring deliverables are on schedule." },
            //    new User { Id = 22, Name = "Paul Andrew Vergara", Email = "pavergara@sscgi.com", Status = Status.Rejected, ContactNumber = "09283456789", Description = "QA engineer with strong attention to detail." },
            //    new User { Id = 23, Name = "Mikaela Joyce Navarro", Email = "mjnavarro@sscgi.com", Status = null, ContactNumber = "09364578912", Description = "Junior accountant assisting in audit preparation." },
            //    new User { Id = 24, Name = "Renato Joseph Ramos", Email = "rjramos@sscgi.com", Status = Status.Approved, ContactNumber = "09173245678", Description = "Software architect designing scalable enterprise systems." },
            //    new User { Id = 25, Name = "Janine May Bautista", Email = "jmbautista@sscgi.com", Status = Status.ForConsideration, ContactNumber = "09456127893", Description = "UX researcher passionate about improving user experience." },
            //    new User { Id = 26, Name = "Cris Anthony Lim", Email = "calim@sscgi.com", Status = Status.Rejected, ContactNumber = "09067893421", Description = "IT support trainee learning network troubleshooting." },
            //    new User { Id = 27, Name = "Hannah Grace Lopez", Email = "hglopez@sscgi.com", Status = Status.Approved, ContactNumber = "09187654321", Description = "Graphic designer specializing in web and print media." },
            //    new User { Id = 28, Name = "Rico Paolo Tan", Email = "rptan@sscgi.com", Status = Status.ForConsideration, ContactNumber = "09275643198", Description = "Business analyst documenting system requirements." },
            //    new User { Id = 29, Name = "Shaira Mae Gutierrez", Email = "smgutierrez@sscgi.com", Status = null, ContactNumber = "09384567901", Description = "Intern assisting the HR department with onboarding tasks." },
            //    new User { Id = 30, Name = "Daniel James Morales", Email = "djmorales@sscgi.com", Status = Status.Rejected, ContactNumber = "09457890321", Description = "Operations assistant with logistics management skills." },
            //};
        }
        #endregion



        #region GetUers
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.Where(x => x.Status == null);

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
            var users = _context.Users.Where(x => x.Status == Status.Approved);

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
            var users = _context.Users.Where(x => x.Status == Status.ForConsideration);

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
            var users = _context.Users.Where(x => x.Status == Status.Rejected);

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
            var result = _context.Users;
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
