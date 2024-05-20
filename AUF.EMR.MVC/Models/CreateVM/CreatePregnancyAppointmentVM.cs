using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.CreateVM
{
    public class CreatePregnancyAppointmentVM : BaseVM
    {
        public PregnancyAppointment PregnancyAppointment { get; set; }
        public int RecordId { get; set; }
    }
}
