using AUF.EMR.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class PregnancyAppointment : BaseDomainEntity
    {
        public PregnancyRecord PregnancyRecord { get; set; }
        public int PregnancyRecordId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public string BloodPressure { get; set; }
        public double Temperature { get; set; }
        public string AOG { get; set; }
        public string FH { get; set; }
        public string FHT { get; set; }
        public string TT1 { get; set; }
        public string TT2 { get; set; }
        public string TT3 { get; set; }
        public string TT4 { get; set; }
        public string TT5 { get; set; }
        public string Remarks { get; set; }
    }
}
