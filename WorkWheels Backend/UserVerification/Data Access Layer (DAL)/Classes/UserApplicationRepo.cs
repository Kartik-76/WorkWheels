using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RideSharingPlatform.Models;
using RideSharingPlatform.UserVerification.Data_Access_Layer__DAL_.Interfaces;

namespace RideSharingPlatform.UserVerification.Data_Access_Layer__DAL_.Classes
{
    public class UserApplicationRepo : IUserApplicationRepo
    {
        private readonly RideSharingPlatformContext _context;
        public UserApplicationRepo(RideSharingPlatformContext context)
        {
            this._context = context;
        }
        public async Task<UserApplication> CreateNewApplication(UserApplication userApplication)
        {
            var result = await _context.UserApplications.AddAsync(userApplication);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<UserApplication>> GetPendingApplications()
        {
            const string PendingStatus = "New";
            var pendingApplication = await _context.UserApplications
                .Where(app=>app.ApplicationStatus == PendingStatus)
                .ToListAsync();
            return pendingApplication;
        }

        public async Task<UserApplication> GetApplicationByUserId(int userId)
        {
            var result = await _context.UserApplications.Where(app=>app.UserId == userId).AsNoTracking().FirstOrDefaultAsync();
            return result;
        }

        public void UpdateApplicationStatus(UserApplication userApplication)
        {
            _context.Entry(userApplication).State = EntityState.Modified;
        }

        public async Task<UserApplication> GetApplicationById(int id)
        {
            return await _context.UserApplications.FindAsync(id);
            
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void DeleteApplication(int userId)
        {
            UserApplication application = _context.UserApplications.Find(userId);
            if (application != null)
            {
                DrivingLicence drivingLicence = _context.DrivingLicences.Where(app=>app.UserId == userId).FirstOrDefault();
                _context.DrivingLicences.Remove(drivingLicence);
                _context.UserApplications.Remove(application);

            }
        }
    }
}
