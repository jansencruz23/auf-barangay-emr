using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class PatientRecordVM : BaseVM
    {
        public List<PatientRecord> PatientRecords { get; set; }
    }
}
