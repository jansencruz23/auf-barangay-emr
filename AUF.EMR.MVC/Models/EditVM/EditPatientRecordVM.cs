using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditPatientRecordVM : BaseVM
    {
        public List<HouseholdMember>? PatientList { get; set; }
        public PatientRecord PatientRecord { get; set; }
    }
}
