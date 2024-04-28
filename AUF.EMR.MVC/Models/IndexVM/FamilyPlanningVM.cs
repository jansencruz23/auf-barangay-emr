using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class FamilyPlanningVM
    {
        public List<FamilyPlanningRecord> FPRecords { get; set; }
        public string HouseholdNo { get; set; }
    }
}
