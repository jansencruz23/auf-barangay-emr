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
        public bool PelvicNormal { get; set; }
        public bool PelvicMass { get; set; }
        public bool PelvicAbnormalDischarge { get; set; }
        public bool PelvicCervicalAbnormalities { get; set; }
        public bool PCAWarts { get; set; }
        public bool PCAPolyp { get; set; }
        public bool PCAInflammation { get; set; }
        public bool PCABloodyDischarge { get; set; }
        public bool PelvicCervicalConsistency { get; set; }
        public CervicalConsistency? CervicalConsistency { get; set; }
        public bool CervicalTenderness { get; set; }
        public bool AdnexalMass { get; set; }
        public bool UterinePosition { get; set; }
        public UterinePosition? UterinePositions { get; set; }
        public bool UterineDepth { get; set; }
        public int? UterineDepthSize { get; set; }

        // PRINT
        public bool SkinNormal { get => Skin == Skin.normal; }
        public bool SkinPale { get => Skin == Skin.pale; }
        public bool SkinYellowish { get => Skin == Skin.yellowish; }
        public bool SkinHematoma { get => Skin == Skin.hematoma; }
        public bool ConjunctivaNormal { get => Conjunctiva == Conjunctiva.normal; }
        public bool ConjunctivaPale { get => Conjunctiva == Conjunctiva.pale; }
        public bool ConjunctivaYellowish { get => Conjunctiva == Conjunctiva.yellowish; }
        public bool NeckNormal { get => Neck == Neck.normal; }
        public bool NeckMass { get => Neck == Neck.neckMass; }
        public bool NeckLymph { get => Neck == Neck.enlargedLymphNodes; }
        public bool BreastNormal { get => Breast == Breast.normal; }
        public bool BreastMass { get => Breast == Breast.mass; }
        public bool BreastNipple { get => Breast == Breast.nippleDischarge; }
        public bool AbdomenNormal { get => Abdomen == Abdomen.normal; }
        public bool AbdomenMass { get => Abdomen == Abdomen.abdominalMass; }
        public bool AbdomenVaricosities { get => Abdomen == Abdomen.varicosities; }
        public bool ExtremitiesNormal { get => Extremities == Extremities.normal; }
        public bool ExtremitiesEdema { get => Extremities == Extremities.edema; }
        public bool ExtremitiesVaricosities { get => Extremities == Extremities.varicosities; }
        public bool CervicalConsistensyFirm { get => CervicalConsistency == Enums.FamilyPlanning.CervicalConsistency.firm; }
        public bool CervicalConsistensySoft { get => CervicalConsistency == Enums.FamilyPlanning.CervicalConsistency.soft; }
        public bool UterineMid { get => UterinePositions == Enums.FamilyPlanning.UterinePosition.mid; }
        public bool UterineAnteflexed { get => UterinePositions == Enums.FamilyPlanning.UterinePosition.anteflexed; }
        public bool UterineRetroflexed { get => UterinePositions == Enums.FamilyPlanning.UterinePosition.retroflexed; }
    }
}
