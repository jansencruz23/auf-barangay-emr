using AUF.EMR.Domain.Models.Common;
using AUF.EMR.Domain.Models.Enums.FamilyPlanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models.FamilyPlanning
{
    public class RisksForSTI : BaseDomainEntity
    {
        public bool AbnormalDischarge { get; set; } 
        public Genitals? Genitals { get; set; }
        public bool HasSoresInGenitalArea { get; set; } 
        public bool HasPainInGenitalArea { get; set; } 
        public bool HadTreatmentForSTI { get; set; }
        public bool HasHIV { get; set; } 

        // PRINT
        public bool? IsVagina { get => Genitals.HasValue && Genitals.Value == Enums.FamilyPlanning.Genitals.Vagina; }
        public bool? IsPenis { get => Genitals.HasValue && Genitals.Value == Enums.FamilyPlanning.Genitals.Penis; }
        public bool NoAbnormalDischarge { get => !AbnormalDischarge; }
        public bool NoSoresInGenitalArea { get => !HasSoresInGenitalArea; }
        public bool NoPainInGenitalArea { get => !HasPainInGenitalArea; }
        public bool NoTreatmentForSTI { get => !HadTreatmentForSTI; }
        public bool NoHIV { get => !HasHIV; }
    }
}
