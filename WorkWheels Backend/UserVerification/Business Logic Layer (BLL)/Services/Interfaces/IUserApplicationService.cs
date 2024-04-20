using Microsoft.AspNetCore.Mvc;
using RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Data_Transfer_Objects__DTOs_.Request_DTOs;
using RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Data_Transfer_Objects__DTOs_.Respose_DTOs;

namespace RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Services.Interfaces
{
    public interface IUserApplicationService
    {
        Task<UserApplicationResponseDTO> CreateNewApplication(UserApplicationRequestDTO userApplicationRequestDTO);
        Task<IEnumerable<UserApplicationResponseDTO>> GetPendingApplications();
        Task<UserApplicationResponseDTO> GetApplicationByUserId(int userId);
        Task<IActionResult> UpdateApplicationStatus(UpdateUserApplicationRequestDTO updateUserApplicationRequestDTO);
    }
}
