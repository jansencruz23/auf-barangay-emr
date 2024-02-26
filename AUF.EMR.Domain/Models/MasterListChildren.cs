using AUF.EMR.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class MasterListChildren : BaseDomainEntity
    {
        public string NameOfMother { get; set; }
        public string NameOfFather { get; set; }
        public bool IsNhts { get; set; }
        public bool IsInSchool { get; set; }
        public int HouseholdMemberId { get; set; }
        public HouseholdMember HouseholdMember { get; set; }
    }
}
