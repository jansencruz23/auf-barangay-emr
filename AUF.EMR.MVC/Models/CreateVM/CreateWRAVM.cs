using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.CreateVM
{
    public class CreateWRAVM : BaseVM
    {
        public string HouseholdNo { get; set; }
        public WomanOfReproductiveAge WRA { get; set; }
        public List<HouseholdMember> WomenInHousehold { get; set; } = new();
    }
}
