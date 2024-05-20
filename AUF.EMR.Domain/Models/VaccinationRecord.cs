using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class VaccinationRecord
    {
        public int VaccinationAppointmentId { get; set; }
        public VaccinationAppointment VaccinationAppointment { get; set; }

        public int VaccineId { get; set; }
        public Vaccine Vaccine { get; set; }
    }
}
