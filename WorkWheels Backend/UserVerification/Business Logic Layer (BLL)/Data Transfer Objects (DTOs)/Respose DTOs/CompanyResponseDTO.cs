using RideSharingPlatform.Models;

namespace RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Data_Transfer_Objects__DTOs_.Respose_DTOs
{
    public class CompanyResponseDTO
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? BuildingName { get; set; }
        public string? SecurityInchargeName { get; set; }
        public string? SecurityHelpDeskNumber { get; set; }
        public CompanyResponseDTO()
        {
            
        }

        public CompanyResponseDTO(Company company)
        {
            this.Id = company.Id;   
            this.CompanyName = company.CompanyName; 
            this.BuildingName = company.BuildingName;
            this.SecurityInchargeName = company.SecurityInchargeName;
            this.SecurityHelpDeskNumber = company.SecurityHelpDeskNumber;
        }
    }
}
