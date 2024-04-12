using AUF.EMR.Domain.Models;

using AUF.EMR.MVC.Models.Common;
namespace AUF.EMR.MVC.Models.CreateVM
{
    public class CreateHouseholdProfileVM : BaseVM
    {
        public Household Household { get; set; } = new();
        public HouseholdMember HouseholdMember { get; set; }
        public List<HouseholdMember> HouseholdMembers { get; set; } = new();
    }
}
