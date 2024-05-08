using AUF.EMR.Domain.Models.Common;
using AUF.EMR.Domain.Models.Enums.FamilyPlanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models.FamilyPlanning
{
    public class PhysicalExamination : BaseDomainEntity
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public string BloodPressure { get; set; }
        public int PulseRate { get; set; }
        public Skin Skin { get; set; }
        public Conjunctiva Conjunctiva { get; set; }
        public Neck Neck { get; set; }
        public Breast Breast { get; set; }
        public Abdomen Abdomen { get; set; }
        public Extremities Extremities { get; set; }
        public bool? PelvicNormal { get; set; }
        public bool? PelvicMass { get; set; }
        public bool? PelvicAbnormalDischarge { get; set; }
        public bool? PelvicCervicalAbnormalities { get; set; }
        public bool? PCAWarts { get; set; }
        public bool? PCAPolyp { get; set; }
        public bool? PCAInflammation { get; set; }
        public bool? PCABloodyDischarge { get; set; }
        public bool? PelvicCervicalConsistency { get; set; }
        public CervicalConsistency? CervicalConsistency { get; set; }
        public bool? CervicalTenderness { get; set; }
        public bool? AdnexalMass { get; set; }
        public bool? UterinePosition { get; set; }
        public UterinePosition? UterinePositions { get; set; }
        public int? UterineDepth { get; set; }
    }
}
