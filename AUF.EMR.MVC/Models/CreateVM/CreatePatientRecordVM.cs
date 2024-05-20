using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.CreateVM
{
    public class CreatePatientRecordVM : BaseVM
    {
        public List<HouseholdMember>? PatientList { get; set; }
        public PatientRecord PatientRecord { get; set; }
    }
}
