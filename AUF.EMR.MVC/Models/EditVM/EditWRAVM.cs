using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditWRAVM
    {
        public WomanOfReproductiveAge WRA { get; set; }
        public List<HouseholdMember> WomenInHousehold { get; set; }
    }
}
