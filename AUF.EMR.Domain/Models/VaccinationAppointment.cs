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
    public class VaccinationAppointment : BaseDomainEntity
    {
        public int PatientRecordId { get; set; }
        public PatientRecord? PatientRecord { get; set; }
        [DataType(DataType.Date)]
        public DateTime VaccinationDate { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public double? Temperature { get; set; }

        public IEnumerable<VaccinationRecord>? VaccinationRecords { get; set; }
    }
}
