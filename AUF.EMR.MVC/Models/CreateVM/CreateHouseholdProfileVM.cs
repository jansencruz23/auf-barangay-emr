using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.CreateVM
{
    public class CreateHouseholdProfileVM
    {
        public Household Household { get; set; } = new();
        public HouseholdMember HouseholdMember { get; set; }
        public List<HouseholdMember> HouseholdMembers { get; set; } = new();
    }
}
