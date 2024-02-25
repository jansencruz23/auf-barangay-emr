using AUF.EMR.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class HouseHoldMember : BaseDomainEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MotherMaidenName { get; set; }
        public string RelationshipToHouseholdHead { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string FirstQtrClassification { get; set; }
        public string SecondQtrClassification { get; set; }
        public string ThirdQtrClassification { get; set; }
        public string FourthQtrClassification { get; set; }
        public string Remarks { get; set; }
        public string HouseHoldNo { get; set; }
        public int? HouseHoldId { get; set; }
        public HouseHold? HouseHold { get; set; }
    }
}
