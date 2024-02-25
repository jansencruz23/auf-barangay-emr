using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models
{
    public class HouseHoldProfileVM
    {
        public Household HouseHold { get; set; } = new();
        public HouseholdMember HouseHoldMember { get; set; }
        public List<HouseholdMember> HouseHoldMembers { get; set; } = new();
    }
}
