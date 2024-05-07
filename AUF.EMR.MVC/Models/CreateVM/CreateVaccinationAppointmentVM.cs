using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.CreateVM
{
    public class CreateVaccinationAppointmentVM : BaseVM
    {
        public VaccinationAppointment Appointment { get; set; }
        public List<Vaccine> Vaccines { get; set; }
        public int PatientId { get; set; }
    }
}
