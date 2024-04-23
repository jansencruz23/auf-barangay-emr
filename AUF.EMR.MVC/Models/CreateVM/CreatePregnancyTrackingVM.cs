using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.Enums;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.CreateVM
{
    public class CreatePregnancyTrackingVM : BaseVM
    {
        public string HouseholdNo { get; set; }
        public PregnancyTracking PregnancyTracking { get; set; }
        public List<HouseholdMember> WomenInHousehold { get; set; } = new();
    }
}
