using System;
using System.Collections.Generic;

namespace RideSharingPlatform.Models
{
    public partial class Company
    {
        public Company()
        {
            UserApplications = new HashSet<UserApplication>();
        }

        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? BuildingName { get; set; }
        public string? SecurityInchargeName { get; set; }
        public string? SecurityHelpDeskNumber { get; set; }

        public virtual ICollection<UserApplication> UserApplications { get; set; }
    }
}
