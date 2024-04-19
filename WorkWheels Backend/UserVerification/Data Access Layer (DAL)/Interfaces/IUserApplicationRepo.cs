﻿using RideSharingPlatform.Models;

namespace RideSharingPlatform.UserVerification.Data_Access_Layer__DAL_.Interfaces
{
    public interface IUserApplicationRepo
    {
        Task <UserApplication> CreateNewApplication(UserApplication userApplication);
    }
}
