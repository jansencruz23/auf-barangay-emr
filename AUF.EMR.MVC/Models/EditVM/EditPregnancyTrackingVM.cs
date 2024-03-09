using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditPregnancyTrackingVM
    {
        public PregnancyTracking PregnancyTracking { get; set; }
        public List<HouseholdMember> WomenInHousehold { get; set; } = new();
    }
}
