using AUF.EMR.Domain.Models;

using AUF.EMR.MVC.Models.Common;
namespace AUF.EMR.MVC.Models.IndexVM
{
    public class PregnancyTrackingListVM : BaseVM
    {
        public PregnancyTrackingHH PregnancyTrackingHH { get; set; }
        public List<PregnancyTracking> PregnancyTrackingList { get; set; }
    }
}
