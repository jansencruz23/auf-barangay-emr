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
    }
}
