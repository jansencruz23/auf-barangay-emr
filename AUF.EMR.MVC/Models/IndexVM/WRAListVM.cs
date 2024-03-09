using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class WRAListVM
    {
        public List<WomanOfReproductiveAge> WRAs { get; set; }
        public string HouseholdNo { get; set; }
    }
}
