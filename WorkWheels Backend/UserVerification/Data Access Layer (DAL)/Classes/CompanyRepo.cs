using Microsoft.EntityFrameworkCore;
using RideSharingPlatform.Models;
using RideSharingPlatform.UserVerification.Data_Access_Layer__DAL_.Interfaces;

namespace RideSharingPlatform.UserVerification.Data_Access_Layer__DAL_.Classes
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly RideSharingPlatformContext _context;

        public CompanyRepo(RideSharingPlatformContext context)
        {
            this._context = context;    
        }

        public async Task <IEnumerable<Company>> GetAllCompanies()
        {
            var result = _context.Companies.AsNoTracking().AsEnumerable();
            return result;
        }
    }
}
