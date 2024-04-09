using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class HouseholdVM
    {
        public List<Household> Households { get; set; }
        public Barangay Barangay { get; set; }
    }
}
