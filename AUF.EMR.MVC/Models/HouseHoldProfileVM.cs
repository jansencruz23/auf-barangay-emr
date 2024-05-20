using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models
{
    public class HouseholdProfileVM : BaseVM
    {
        public Household Household { get; set; }
        public string HouseholdNo { get; set; }
    }
}
