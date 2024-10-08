﻿using AUF.EMR.Domain.Models.Common;
using AUF.EMR.Domain.Models.FamilyPlanning;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class FamilyPlanningRecord : BaseDomainEntity
    {
        public string ClientId { get; set; }
        public string? PhilhealthNo { get; set; }
        public HouseholdMember? ClientHouseholdMember { get; set; }
        public int ClientHouseholdMemberId { get; set; }
        public int ClientAge { get; set; }
        public string ClientOccupation { get; set; }
        public string ContactNo { get; set; }
        public string CivilStatus { get; set; } 
        public string Religion { get; set; }
        public string SpouseLastName { get; set; }
        public string SpouseFirstName { get; set; }
        public string? SpouseMiddleInitial { get; set; }
        [DataType(DataType.Date)]
        public DateTime SpouseBirthday { get; set; }
        public int SpouseAge { get; set; }
        public string SpouseOccupation { get; set; }
        public int? LivingChildrenNo { get; set; }
        public bool IsPlanningChildren { get; set; }
        public double? AverageMonthlyIncome { get; set; }
        public int ClientTypeId { get; set; }
        public ClientType? ClientType { get; set; }
        public int MedicalHistoryId { get; set; }
        public MedicalHistory? MedicalHistory { get; set; }
        public int ObstetricalHistoryId { get; set; }
        public ObstetricalHistory? ObstetricalHistory { get; set; }
        public int RisksForSTIId { get; set; }
        public RisksForSTI? RisksForSTI { get; set; }
        public int RisksForVAWId { get; set; }
        public RisksForVAW? RisksForVAW { get; set; }
        public int PhysicalExaminationId { get; set; }
        public PhysicalExamination? PhysicalExamination { get; set; }
        public string FPMethod { get; set; }
        public string? ClientSignatureAcknowledgement { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAcknowledgement { get; set; }
        public string? ClientSignatureConsent { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateConsent { get; set; }

        // PRINTING
        public bool? NotPlanningChildren { get => !IsPlanningChildren; }

    }
}
