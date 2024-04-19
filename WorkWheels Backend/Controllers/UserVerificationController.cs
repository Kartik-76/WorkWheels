using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Data_Transfer_Objects__DTOs_.Request_DTOs;
using RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Services.Classes;
using RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Services.Interfaces;

namespace RideSharingPlatform.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserVerificationController : ControllerBase
    {
        private readonly ICompanyServices _companyServices;
        private readonly IUserApplicationService _userApplicationService;

        public UserVerificationController(ICompanyServices companyServices, IUserApplicationService userApplicationService) 
        {
             this._companyServices = companyServices;
             this._userApplicationService = userApplicationService;
        }
        [HttpGet("companies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var result = await _companyServices.GetAllCompanies();
            return Ok(result);
        }

        [HttpPost("applications/new")]

        public async Task <IActionResult> CreateNewApplication(UserApplicationRequestDTO userApplicationRequestDTO)
        {
            try
            {
                var result = await _userApplicationService.CreateNewApplication(userApplicationRequestDTO);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpGet("applications")]
        public async Task<IActionResult> GetPendingApplications()
        {
            var result = await _userApplicationService.GetPendingApplications();
            return Ok(result);
        }
    }
}
