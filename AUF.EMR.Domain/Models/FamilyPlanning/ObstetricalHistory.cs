using AUF.EMR.Domain.Models.Common;
using AUF.EMR.Domain.Models.Enums.FamilyPlanning;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models.FamilyPlanning
{
    public class ObstetricalHistory : BaseDomainEntity
    {
        public int NumGravidityPregnancies { get; set; }
        public int NumParityPregnancies { get; set; }
        public int? NumFullTerm { get; set; }
        public int? NumAbortion { get; set; }
        public int? NumPremature { get; set; }
        public int? NumLivingChildren { get; set; }
        [DataType(DataType.Date)]
        public DateTime? LastDelivery { get; set; }
        public bool? IsLastDeliveryVaginal { get; set; }
        [DataType(DataType.Date)]
        public DateTime? LastMenstrualPeriod { get; set; }
        [DataType(DataType.Date)]
        public DateTime? PreviousMenstrualPeriod { get; set; }
        public MenstrualFlow MestrualFlow { get; set; }
        public bool HasDysmenorrhea { get; set; } 
        public bool HasHydatidiformMole { get; set; } 
        public bool HadEctopicPregnancy { get; set; } 
    }
}
