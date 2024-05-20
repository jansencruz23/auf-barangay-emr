using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.DetailVM
{
    public class DetailPatientRecordVM : BaseVM
    {
        public PatientRecord PatientRecord { get; set; }
    }
}
