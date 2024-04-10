using AUF.EMR.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models.Common
{
    public class BaseDomainEntity
    {
        public int Id { get; set; }
        public bool Status { get; set; } = true;
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public Guid? ModifiedById { get; set; }
    }
}
