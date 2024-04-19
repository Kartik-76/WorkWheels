using RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Data_Transfer_Objects__DTOs_.Respose_DTOs;
using RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Services.Interfaces;
using RideSharingPlatform.UserVerification.Data_Access_Layer__DAL_.Interfaces;

namespace RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Services.Classes
{
    public class CompanyServices : ICompanyServices
    {
        private readonly ICompanyRepo _companyRepo;

        public CompanyServices(ICompanyRepo companyRepo)
        {
            this._companyRepo = companyRepo;
        }
        public async Task<IEnumerable<CompanyResponseDTO>> GetAllCompanies()
        {
            var result = await _companyRepo.GetAllCompanies();
            List<CompanyResponseDTO> companyResponseDTOs = new();
            foreach (var company in result)
            {
                var companyResponse = new CompanyResponseDTO(company);
                companyResponseDTOs.Add(companyResponse);
            }
            return companyResponseDTOs;
        }
    }
}
