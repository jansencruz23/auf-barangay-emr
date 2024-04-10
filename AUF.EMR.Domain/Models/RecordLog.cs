using AUF.EMR.Domain.Models.Common;
using AUF.EMR.Domain.Models.Enums;
using AUF.EMR.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class RecordLog
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid? ModifiedById { get; set; }
    }
}