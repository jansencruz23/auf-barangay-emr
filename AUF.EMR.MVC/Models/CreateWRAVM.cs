using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models
{
    public class CreateWRAVM
    {
        public string HouseholdNo { get; set; }
        public WomanOfReproductiveAge WRA { get; set; }
        public List<HouseholdMember> HouseholdMembers { get; set; } = new();
    }
}
