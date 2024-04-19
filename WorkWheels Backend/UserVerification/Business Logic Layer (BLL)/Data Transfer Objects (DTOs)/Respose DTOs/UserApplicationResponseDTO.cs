using RideSharingPlatform.Models;
using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Data_Transfer_Objects__DTOs_.Respose_DTOs
{
    public class UserApplicationResponseDTO
    {
        public int UserId { get; set; }

        public string? Username { get; set; }
        public string? OfficialEmail { get; set; }
        
        public string? Phoneno { get; set; }
        public int? CompanyId { get; set; }
        public string? Designation { get; set; }
        public string? Role { get; set; }
        public string? EmployeeId { get; set; }
        public string? AadharNumber { get; set; }
        public string? ApplicationStatus { get; set; }
        public string? LicenseNo { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? Rto { get; set; }

        public UserApplicationResponseDTO()
        {
            
        }

        public UserApplicationResponseDTO(UserApplication userApplication, DrivingLicence drivingLicence)
        {
            this.UserId = userApplication.UserId;
            this.Username = userApplication.Username;
            this.OfficialEmail = userApplication.OfficialEmail;
            this.Phoneno = userApplication.Phoneno;
            this.CompanyId = userApplication.CompanyId;
            this.Designation = userApplication.Designation;
            this.Role = userApplication.Role;
            this.EmployeeId = userApplication.EmployeeId;
            this.AadharNumber = userApplication.AadharNumber;
            this.ApplicationStatus = userApplication.ApplicationStatus;
            this.LicenseNo = drivingLicence.LicenseNo;
            this.ExpirationDate = drivingLicence.ExpirationDate;
            this.Rto = drivingLicence.Rto;  
        }
    }
}
