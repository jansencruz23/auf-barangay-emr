using AUF.EMR.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models.FamilyPlanning
{
    public class MedicalHistory : BaseDomainEntity
    {
        public bool HasSevereHeadache { get; set; }
        public bool HasHeartAttack { get; set; }
        public bool HasHematoma { get; set; }
        public bool HasBreastCancer { get; set; }
        public bool HasChestPain { get; set; }
        public bool HasCough { get; set; }
        public bool HasJaundice { get; set; }
        public bool HasVaginalBleeding { get; set; }
        public bool HasAbnormalDischarge { get; set; }
        public bool HasTakenRifampicin { get; set; }
        public bool IsSmoker { get; set; }
        public bool HasDisability { get; set; }
        public string? Disability { get; set; }

        // PRINTS
        public bool NoSevereHeadache { get => !HasSevereHeadache; }
        public bool NoHeartAttack { get => !HasHeartAttack; }
        public bool NoHematoma { get => !HasHematoma; }
        public bool NoBreastCancer { get => !HasBreastCancer; }
        public bool NoChestPain { get => !HasChestPain; }
        public bool NoCough { get => !HasCough; }
        public bool NoJaundice { get => !HasJaundice; }
        public bool NoVaginalBleeding { get => !HasVaginalBleeding; }
        public bool NoAbnormalDischarge { get => !HasAbnormalDischarge; }
        public bool NoTakenRifampicin { get => !HasTakenRifampicin; }
        public bool NoSmoker { get => !IsSmoker; }
        public bool NoDisability { get => !HasDisability; }
    }
}
