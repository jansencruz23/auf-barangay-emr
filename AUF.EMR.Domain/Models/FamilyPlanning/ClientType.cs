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
        public bool? IsMethodImplant { get; set; } 
        public bool? IsMethodInjectable { get; set; } 
        public bool? IsMethodLAM { get; set; } 
        public bool? IsMethodIUD { get; set; } 
        public bool? IsMethodCOC { get; set; } 
        public bool? IsMethodSDM { get; set; } 
        public bool? IsMethodBTL { get; set; } 
        public bool? IsMethodPOP { get; set; } 
        public bool? IsMethodBBT { get; set; }
        public bool? IsMethodNSV { get; set; } 
        public bool? IsMethodCondom { get; set; } 
        public bool? IsMethodBOM { get; set; } 
    }
}
