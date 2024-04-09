using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models
{
    public class HouseholdProfileVM
    {
        public List<Household> Households { get; set; }
        public Household Household { get; set; }
        public string HouseholdNo { get; set; }
        public Barangay Barangay { get; set; }
    }
}
