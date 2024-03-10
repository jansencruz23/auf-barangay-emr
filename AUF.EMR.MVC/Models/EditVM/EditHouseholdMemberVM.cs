using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditHouseholdMemberVM
    {
        public HouseholdMember HouseholdMember { get; set; }
        public string ReturnUrl { get; set; }
    }
}
