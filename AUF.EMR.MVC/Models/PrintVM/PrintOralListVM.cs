using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.PrintVM
{
    public class PrintOralListVM : BaseVM
    {
        public List<HouseholdMember> Infants { get; set; }
        public List<HouseholdMember> OneToFour { get; set; }
        public List<HouseholdMember> FiveToNine { get; set; }
        public List<HouseholdMember> TenToFourteen { get; set; }
        public List<HouseholdMember> PregnantFifteenToNineteen { get; set; }
        public List<HouseholdMember> PregnantTwentyToFourtyNine { get; set; }
    }
}
