using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditHouseholdMemberVM : BaseVM
    {
        public HouseholdMember HouseholdMember { get; set; }
        public string RequestUrl { get; set; }
    }
}
