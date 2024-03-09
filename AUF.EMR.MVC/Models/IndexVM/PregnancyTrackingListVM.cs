using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class PregnancyTrackingListVM
    {
        public List<PregnancyTracking> PregnancyTrackingList { get; set; }
        public string HouseholdNo { get; set; }
    }
}
