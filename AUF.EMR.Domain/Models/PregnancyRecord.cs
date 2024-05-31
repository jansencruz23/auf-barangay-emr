using AUF.EMR.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class PregnancyRecord : BaseDomainEntity
    {
        public HouseholdMember? Patient { get; set; } 
        public int PatientId { get; set; }
        public int Age { get; set; }
        public string Husband { get; set; }
        public int Gravida { get; set; }
        public int Para { get; set; }
        [DataType(DataType.Date)]
        public DateTime LMP { get; set; }
        public string CellphoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime EDC { get; set; }

        public List<PregnancyAppointment>? PregnancyAppointments { get; set; }
    }
}
