using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Services.Interfaces;

namespace RideSharingPlatform.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserVerificationController : ControllerBase
    {
        private readonly ICompanyServices _companyServices;

        public UserVerificationController(ICompanyServices companyServices) 
        {
             this._companyServices = companyServices;
        }
        [HttpGet("companies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var result = await _companyServices.GetAllCompanies();
            return Ok(result);
        }
    }
}
