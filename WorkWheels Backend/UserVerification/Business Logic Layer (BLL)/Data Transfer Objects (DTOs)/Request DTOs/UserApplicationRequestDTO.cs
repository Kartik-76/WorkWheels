using RideSharingPlatform.Models;
using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Data_Transfer_Objects__DTOs_.Request_DTOs
{
    public class UserApplicationRequestDTO
    {
        public string? Username { get; set; }
        public string? OfficialEmail { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string? Phoneno { get; set; }
        public int? CompanyId { get; set; }
        public string? Designation { get; set; }
        [RegularExpression(@"^(Motorist|Rider|SecurityHead)$", ErrorMessage = "Invalid Role")]
        public string? Role { get; set; }
        public string? EmployeeId { get; set; }
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Aadhar number must be 12 digits")]
        public string? AadharNumber { get; set; }
        [RegularExpression(@"^(New|Approved|Rejected)$", ErrorMessage = "Invalid Application Status")]
        public string? ApplicationStatus { get; set; }
        public string? LicenseNo { get; set; }
        //[CustomValidation(typeof(DrivingLicence), "ValidateExpirationDate")]
        public DateTime? ExpirationDate { get; set; }
        public string? Rto { get; set; }

        //public static ValidationResult ValidateExpirationDate(DateTime value, ValidationContext context)
        //{
        //    if (value.Date < DateTime.Today)    
        //    {
        //        return new ValidationResult("Expiration date must not be a past date");
        //    }
        //    return ValidationResult.Success;
        //}
    }
}
