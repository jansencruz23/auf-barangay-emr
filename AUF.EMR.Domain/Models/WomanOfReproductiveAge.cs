using AUF.EMR.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class WomanOfReproductiveAge : BaseDomainEntity
    {
        public int HouseholdMemberId { get; set; }
        public HouseholdMember HouseholdMember { get; set; }
        public string HouseholdNo { get; set; }
        public int CivilStatus { get; set; }
        public bool IsPlanningChildren { get; set; }
        public bool? IsPlanChildrenNow { get; set; }
        public bool? IsPlanChildrenSpacing { get; set; }
        public bool? IsPlanChildrenLimiting { get; set; }
        public bool IsFecund { get; set; }
        public bool IsFPMethod { get; set; }
        public bool? IsFPModern { get; set; }
        public bool? ShiftToModern { get; set; }
        public bool IsMFPUnmet { get; set; }
        public bool AcceptModernFpMethod { get; set; }
        public string? ModernFPMethod { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FPAcceptedDate { get; set; }
    }
}
