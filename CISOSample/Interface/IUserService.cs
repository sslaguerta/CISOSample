using CISOSample.Models.ViewModels;

namespace CISOSample.Interface
{
    public interface IUserService
    {
        IList<UserViewModel> GetUsers();
        IList<UserViewModel> GetApprovedUsers();
        IList<UserViewModel> GetForConsiderationUsers();
        IList<UserViewModel> GetRejectedUsers();
        UserViewModel ViewUser(int id);

    }
}
