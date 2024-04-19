using RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Data_Transfer_Objects__DTOs_.Respose_DTOs;

namespace RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Services.Interfaces
{
    public interface ICompanyServices
    {
        Task<IEnumerable<CompanyResponseDTO>> GetAllCompanies();
    }
}
