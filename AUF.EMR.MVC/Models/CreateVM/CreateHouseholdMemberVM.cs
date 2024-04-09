using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.CreateVM
{
    public class CreateHouseholdMemberVM
    {
        public HouseholdMember HouseholdMember { get; set; }
        public string HouseholdNo { get; set; }
        public int HouseholdId { get; set; }
        public Barangay Barangay { get; set; }
    }
}
