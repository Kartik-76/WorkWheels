﻿using RideSharingPlatform.Models;
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
    }
}