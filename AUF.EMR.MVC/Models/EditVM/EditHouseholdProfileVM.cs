using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditHouseholdProfileVM
    {
        public Household Household { get; set; } = new();
        public HouseholdMember HouseholdMember { get; set; }
        public List<HouseholdMember> HouseholdMembers { get; set; } = new();
        public string RequestUrl { get; set; }
    }
}
