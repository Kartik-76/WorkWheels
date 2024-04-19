using RideSharingPlatform.Models;

namespace RideSharingPlatform.UserVerification.Data_Access_Layer__DAL_.Interfaces
{
    public interface ICompanyRepo
    {
        Task <IEnumerable<Company>> GetAllCompanies();
    }
}
