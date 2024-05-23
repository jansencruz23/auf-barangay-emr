using AUF.EMR.Domain.Models.Common;
using AUF.EMR.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class PregnancyTracking : BaseDomainEntity
    {
        public int HouseholdMemberId { get; set; }
        public HouseholdMember HouseholdMember { get; set; }
        public int Age { get; set; }
        public int Gravidity { get; set; }
        public int Parity { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpectedDateOfDelivery { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FirstAntenatalCheckUp{ get; set; }
        [DataType(DataType.Date)]
        public DateTime? SecondAntenatalCheckUp { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ThirdAntenatalCheckUp { get; set; }
        [DataType(DataType.Date)]
        public DateTime? MoreCheckUp { get; set; }
        public PregnancyOutcome? PregnancyOutcome { get; set; }
        [DataType(DataType.Date)]
        public DateTime? PostnatalCheckUp24hrs { get; set; }
        [DataType(DataType.Date)]
        public DateTime? PostnatalCheckUp7days { get; set; }
        [DataType(DataType.Date)]
        public DateTime? LiveBirth { get; set; }
        [DataType(DataType.Date)]
        public DateTime? MaternalDeath { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StillBirth { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EarlyNewbornDeath { get; set; }

        public bool? PregnancyOutcomeLiveBirth { get => PregnancyOutcome.Value == Enums.PregnancyOutcome.LiveBirth; }
        public bool? PregnancyOutcomePreterm { get => PregnancyOutcome.Value == Enums.PregnancyOutcome.PretermBirth; }
        public bool? PregnancyOutcomeStillbirth { get => PregnancyOutcome.Value == Enums.PregnancyOutcome.StillBirth; }
        public bool? PregnancyOutcomeAbortion { get => PregnancyOutcome.Value == Enums.PregnancyOutcome.Abortion; }
    }
}
