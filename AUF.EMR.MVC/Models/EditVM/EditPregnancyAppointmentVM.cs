using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditPregnancyAppointmentVM : BaseVM
    {
        public PregnancyAppointment PregnancyAppointment { get; set; }
        public int RecordId { get; set; }
    }
}
