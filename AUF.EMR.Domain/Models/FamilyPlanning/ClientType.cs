using AUF.EMR.Domain.Models.Common;
using AUF.EMR.Domain.Models.Enums.FamilyPlanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models.FamilyPlanning
{
    public class ClientType : BaseDomainEntity
    {
        public bool IsCurrentUser { get; set; }
        public CurrentUserType? CurrentUserType { get; set; }
        public ReasonForFP? ReasonForFP { get; set; }
        public string? ReasonOthers { get; set; }
        public bool? IsReasonMedical { get; set; }
        public bool? IsReasonSideEffects { get; set; }
        public string? ReasonMethodText { get; set; }
        public bool? IsMethodImplant { get; set; } = false;
        public bool? IsMethodInjectable { get; set; } = false;
        public bool? IsMethodLAM { get; set; } = false;
        public bool? IsMethodIUD { get; set; } = false;
        public bool? IsMethodCOC { get; set; } = false;
        public bool? IsMethodSDM { get; set; } = false;
        public bool? IsMethodBTL { get; set; } = false;
        public bool? IsMethodPOP { get; set; } = false;
        public bool? IsMethodBBT { get; set; } = false;
        public bool? IsMethodNSV { get; set; } = false;
        public bool? IsMethodCondom { get; set; } = false;
        public bool? IsMethodBOM { get; set; } = false;
    }
}
