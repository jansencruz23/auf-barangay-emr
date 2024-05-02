using AUF.EMR.Domain.Models.Common;
using AUF.EMR.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class PatientRecord : BaseDomainEntity
    {
        public int PatientId { get; set; }
        public HouseholdMember? Patient { get; set; }
        public string BirthPlace { get; set; }
        public string MotherName { get; set; }
        public int MotherAge { get; set; }

        [DataType(DataType.Date)]
        [Date]
        public DateTime MotherBirthday { get; set; }
        public string FatherName { get; set; }
        public int FatherAge { get; set; }

        [DataType(DataType.Date)]
        [Date(ErrorMessage = "{0} is invalid")]
        public DateTime FatherBirthday { get; set; }
        public string ContactNumber { get; set; }
        public string TypeOfDelivery { get; set; }
        public string Attended { get; set; }

        public List<VaccinationAppointment>? VaccinationAppointments { get; set; }
    }
}
