using CISOSample.Data;
using CISOSample.Interface;
using CISOSample.Models;
using CISOSample.Models.ViewModels;

namespace CISOSample.Service
{
    public class UserService : IUserService
    {
        #region Context
        private readonly AppDbContext _context;


        public UserService(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region GetUers
        public IList<UserViewModel> GetUsers()
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
            return viewModel;
        }

        public IList<UserViewModel> GetApprovedUsers()
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

            return viewModel;
        }

        public IList<UserViewModel> GetForConsiderationUsers()
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

            return viewModel;
        }

        public IList<UserViewModel> GetRejectedUsers()
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

            return viewModel;
        }


        public UserViewModel ViewUser(int id)
        {
            var result = _context.Users;
            var user = result.FirstOrDefault(x => x.Id == id);

            //if (user == null)
            //    return NotFound(new { mesage = "user not found" });

            var viewModel = new UserViewModel
            {
                Id = user.Id,
                Name = user?.Name,
                Email = user?.Email,
                ContactNumber = user?.ContactNumber,
                Description = user?.Description,
                Status = user?.Status,
            };

            return viewModel;
        }
        #endregion

        public bool ChangeStatus(string command, int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return false;
            }

            switch (command)
            {
                case "Approved":
                    user.Status = Status.Approved;
                    break;
                case "Rejected":
                    user.Status = Status.Rejected;
                    break;
                case "ForConsideration":
                    user.Status = Status.ForConsideration;
                    break;
                default:
                    return false;
            }
            _context.SaveChanges();
            return true;
        }
    }
}
