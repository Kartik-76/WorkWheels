using System;
using System.Collections.Generic;

namespace RideSharingPlatform.Models
{
    public partial class DrivingLicence
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? LicenseNo { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? Rto { get; set; }
        public string? AllowedVehicle { get; set; }

        public virtual UserApplication? User { get; set; }
    }
}
