using AUF.EMR.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class Household : BaseDomainEntity
    {
        public string HouseholdNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FirstQtrVisit { get; set; }

        [DataType(DataType.Date)]
        public DateTime? SecondQtrVisit { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ThirdQtrVisit { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FourthQtrVisit { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MotherMaidenName { get; set; }
        public string HouseNoAndStreet { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ContactNo { get; set; }
        public bool IsNHTS { get; set; }
        public bool IsHeadPhilhealthMember { get; set; }
        public string? PhilhealthNo { get; set; }
        public string? Category { get; set; }
        public bool IsIP { get; set; }
        public bool Status { get; set; } = true;
        public List<HouseholdMember> HouseholdMembers { get; set; } = new();
    }
}
