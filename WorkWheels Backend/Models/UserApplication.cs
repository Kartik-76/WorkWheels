using System;
using System.Collections.Generic;

namespace RideSharingPlatform.Models
{
    public partial class UserApplication
    {
        public UserApplication()
        {
            DrivingLicences = new HashSet<DrivingLicence>();
        }

        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? OfficialEmail { get; set; }
        public string? Phoneno { get; set; }
        public int? CompanyId { get; set; }
        public string? Designation { get; set; }
        public string? Role { get; set; }
        public string? EmployeeId { get; set; }
        public string? AadharNumber { get; set; }
        public string? ApplicationStatus { get; set; }

        public virtual Company? Company { get; set; }
        public virtual ICollection<DrivingLicence> DrivingLicences { get; set; }
    }
}
