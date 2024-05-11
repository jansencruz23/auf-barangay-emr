using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditVaccinationAppointmentVM : BaseVM
    {
        public VaccinationAppointment Appointment { get; set; }
        public List<Vaccine> Vaccines { get; set; }
        public List<Vaccine> SelectedVaccines { get; set; } = new List<Vaccine>();
        public int PatientId { get; set; }
    }
}
