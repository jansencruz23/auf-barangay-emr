using AUF.EMR.Domain.Models;

using AUF.EMR.MVC.Models.Common;
namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditHouseholdProfileVM : BaseVM
    {
        public Household Household { get; set; } = new();
        public HouseholdMember HouseholdMember { get; set; }
        public List<HouseholdMember> HouseholdMembers { get; set; } = new();
        public string RequestUrl { get; set; }
    }
}
