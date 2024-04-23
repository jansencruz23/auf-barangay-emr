using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class HouseholdVM : BaseVM
    {
        public List<Household> Households { get; set; }
    }
}
