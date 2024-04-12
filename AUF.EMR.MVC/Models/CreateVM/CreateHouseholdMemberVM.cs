using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.CreateVM
{
    public class CreateHouseholdMemberVM : BaseVM
    {
        public HouseholdMember HouseholdMember { get; set; }
        public string HouseholdNo { get; set; }
        public int HouseholdId { get; set; }
    }
}
