using AUF.EMR.Domain.Models;

using AUF.EMR.MVC.Models.Common;
namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditPregnancyTrackingVM : BaseVM
    {
        public PregnancyTracking PregnancyTracking { get; set; }
        public List<HouseholdMember> WomenInHousehold { get; set; } = new();
        public string HouseholdNo { get; set; }
    }
}
