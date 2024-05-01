using AUF.EMR.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class PatientRecord : BaseDomainEntity
    {
        public HouseholdMember Patient { get; set; }
        public int PatientId { get; set; }
        public string BirthPlace { get; set; }
    }
}
