using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models
{
    public class WRAListVM
    {
        public List<WomanOfReproductiveAge> WRAs { get; set; }
        public string HouseholdNo { get; set; }
    }
}
