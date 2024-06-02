using AUF.EMR.Application.Common;
using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class HouseholdVM : BaseVM
    {
        public PaginatedList<Household> Households { get; set; }
        public string Query { get; set; }
    }
}
