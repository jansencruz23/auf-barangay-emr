using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditWRAVM : BaseVM
    {
        public WomanOfReproductiveAge WRA { get; set; }
        public List<HouseholdMember> WomenInHousehold { get; set; }
        public string HouseholdNo { get; set; }
    }
}
