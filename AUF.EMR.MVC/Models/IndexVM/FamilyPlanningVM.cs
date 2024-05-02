using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class FamilyPlanningVM : BaseVM
    {
        public List<FamilyPlanningRecord> FPRecords { get; set; }
    }
}
