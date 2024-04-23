using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.PrintVM
{
    public class PrintAdultsMasterlistVM : BasePrintListVM
    {
        public List<HouseholdMember> Adults { get; set; }
        public string RequestUrl { get; set; }
    }
}
