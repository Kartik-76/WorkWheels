using RideSharingPlatform.Models;

namespace RideSharingPlatform.UserVerification.Data_Access_Layer__DAL_.Interfaces
{
    public interface IUserApplicationRepo
    {
        Task <UserApplication> CreateNewApplication(UserApplication userApplication);
        Task <IEnumerable<UserApplication>> GetPendingApplications();
        Task<UserApplication> GetApplicationByUserId(int userId);

        void UpdateApplicationStatus(UserApplication userApplication);
        Task<UserApplication> GetApplicationById(int id);
        Task<int> SaveChangesAsync();
        
        void DeleteApplication(int userId);
    }
}
