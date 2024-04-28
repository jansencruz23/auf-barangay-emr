using AUF.EMR.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class PregnancyTrackingHH : BaseDomainEntity
    {
        public int Year { get; set; }
        public string? Region { get; set; }
        public string? Province { get; set; }
        public string? Municipality { get; set; }
        public string? Barangay { get; set; }
        public string? BirthingCenter { get; set; }
        public string? BirthingCenterAddress { get; set; }
        public string? ReferralCenter { get; set; }
        public string? ReferralCenterAddress { get; set; }
        public string? BHWName { get; set; }
        public string MidwifeName { get; set; }
        public string? BarangayHealthStation { get; set; }
        public string? RuralHealthUnit { get; set; }
        public Household? Household { get; set; }
        public int HouseholdId { get; set; }
    }
}
