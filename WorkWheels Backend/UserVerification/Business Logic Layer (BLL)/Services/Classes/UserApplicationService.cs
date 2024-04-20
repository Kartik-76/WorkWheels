using Microsoft.IdentityModel.Tokens;
using RideSharingPlatform.Models;
using RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Data_Transfer_Objects__DTOs_.Request_DTOs;
using RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Data_Transfer_Objects__DTOs_.Respose_DTOs;
using RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Services.Interfaces;
using RideSharingPlatform.UserVerification.Data_Access_Layer__DAL_.Classes;
using RideSharingPlatform.UserVerification.Data_Access_Layer__DAL_.Interfaces;

namespace RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Services.Classes
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserApplicationRepo _userApplicationRepo;

        public UserApplicationService(IUserApplicationRepo userApplicationRepo)
        {
            this._userApplicationRepo = userApplicationRepo;
        }

        // Handling POST Method for creating new User Application

        public async Task<UserApplicationResponseDTO> CreateNewApplication(UserApplicationRequestDTO userApplicationRequestDTO)
        {
            if (userApplicationRequestDTO == null || !IsValid(userApplicationRequestDTO))
            {
                throw new ArgumentException("Invalid Data Entered. Try Again");
            }
            var newApplication = new UserApplication
            { 
                Username = userApplicationRequestDTO.Username,
                OfficialEmail = userApplicationRequestDTO.OfficialEmail,
                Phoneno = userApplicationRequestDTO.Phoneno,
                CompanyId = userApplicationRequestDTO.CompanyId,
                Designation = userApplicationRequestDTO.Designation,
                Role = userApplicationRequestDTO.Role,
                EmployeeId = userApplicationRequestDTO.EmployeeId,
                AadharNumber = userApplicationRequestDTO.AadharNumber,
                ApplicationStatus = userApplicationRequestDTO.ApplicationStatus,

                DrivingLicences = new List<DrivingLicence>
                {
                    new DrivingLicence
                    {
                        LicenseNo = userApplicationRequestDTO.LicenseNo,
                        ExpirationDate = userApplicationRequestDTO.ExpirationDate,  
                        AllowedVehicle = "",
                        Rto = userApplicationRequestDTO.Rto,

                    }
                }

            };
            var result = await _userApplicationRepo.CreateNewApplication(newApplication);
            UserApplicationResponseDTO newApplicationResponse = new()
            {
                UserId = result.UserId,
                Username = result.Username,
                OfficialEmail = result.OfficialEmail,
                Phoneno = result.Phoneno,
                CompanyId = result.CompanyId,   
                Designation = result.Designation,
                Role = result.Role,
                EmployeeId = result.EmployeeId,
                AadharNumber= result.AadharNumber,
                ApplicationStatus = result.ApplicationStatus,
            };
            return newApplicationResponse;

        }

        // Handling Get Method for Fetching all the pending Applications 
        public async Task<IEnumerable<UserApplicationResponseDTO>> GetPendingApplications()
        {
            var result = await _userApplicationRepo.GetPendingApplications();
            List<UserApplicationResponseDTO> userApplicationResponseDTOs = new();
            foreach(var applications in result)
            {
                var applicationResponse = new UserApplicationResponseDTO(applications);
                userApplicationResponseDTOs.Add(applicationResponse);
            }
            return (IEnumerable<UserApplicationResponseDTO>)userApplicationResponseDTOs;
        }

        // Handling GET Method for Fetching Application of particular user
        public async Task<UserApplicationResponseDTO> GetApplicationByUserId(int userId)
        {
            var result = await _userApplicationRepo.GetApplicationByUserId(userId);
            var applicationResponse = new UserApplicationResponseDTO(result);
            return applicationResponse;
        }







        //Double validation checker methods
        private bool IsValid(UserApplicationRequestDTO userApplicationRequestDTO)
        {
            if(!IsValidRegistrationStatus(userApplicationRequestDTO.ApplicationStatus)) { return false; }
            if (!IsValidUserRole(userApplicationRequestDTO.Role)) { return false; }
            return true;
        }

        private bool IsValidUserRole(string applicationStatus)
        {
            var allowedStatusValues = new List<string> { "Motorist", "Rider", "SecurityHead" };
            return allowedStatusValues.Contains(applicationStatus);
        }

        private bool IsValidRegistrationStatus(string role)
        {
            var allowedRiderValues = new List<string> { "New", "Approved", "Rejected" }; 
            return allowedRiderValues.Contains(role);
        }
    }
}
