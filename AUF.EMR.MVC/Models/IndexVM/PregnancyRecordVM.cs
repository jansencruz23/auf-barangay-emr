using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class PregnancyRecordVM : BaseVM
    {
        public List<PregnancyRecord> PregnancyRecords { get; set; }
    }
}
