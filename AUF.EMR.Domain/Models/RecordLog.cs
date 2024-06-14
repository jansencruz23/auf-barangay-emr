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
        public DateTime Timestamp { get; set; }
        public string Action { get; set; }
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public Guid? ModifiedById { get; set; }
    }
}
