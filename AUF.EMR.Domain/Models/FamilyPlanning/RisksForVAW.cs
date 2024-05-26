using AUF.EMR.Domain.Models.Common;
using AUF.EMR.Domain.Models.Enums.FamilyPlanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models.FamilyPlanning
{
    public class RisksForVAW : BaseDomainEntity
    {
        public bool HadVAW { get; set; }
        public bool HadUnpleasantRelationship { get; set; }
        public bool PartnerNotApproveFP { get; set; }
        public VAWReferredTo ReferredTo { get; set; }
        public string? ReferredToOthers { get; set; }

        // PRINT
        public bool NoVAW { get => !HadVAW; }
        public bool NoUnpleasantRelationship { get => !HadUnpleasantRelationship; }
        public bool NotPartnerNotApproveFP { get => !PartnerNotApproveFP; }
        public bool VAWReferredToDSWD { get => ReferredTo == VAWReferredTo.DSWD; }
        public bool VAWReferredToWCPU { get => ReferredTo == VAWReferredTo.WCPU; }
        public bool VAWReferredToNGOs { get => ReferredTo == VAWReferredTo.NGOs; }
        public bool VAWReferredToOthers { get => ReferredTo == VAWReferredTo.Others; }
    }
}
