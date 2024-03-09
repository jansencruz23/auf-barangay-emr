using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.CreateVM
{
    public class CreateWRAVM
    {
        public string HouseholdNo { get; set; }
        public WomanOfReproductiveAge WRA { get; set; }
        public List<HouseholdMember> WomenInHousehold { get; set; } = new();
    }
}
