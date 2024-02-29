using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models
{
    public class CreateHouseholdMemberVM
    {
        public HouseholdMember HouseholdMember { get; set; }
        public string HouseholdNo { get; set; }
    }
}
