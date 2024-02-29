using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models
{
    public class CreateHouseholdProfileVM
    {
        public Household Household { get; set; } = new();
        public HouseholdMember HouseholdMember { get; set; }
        public List<HouseholdMember> HouseholdMembers { get; set; } = new();
    }
}
