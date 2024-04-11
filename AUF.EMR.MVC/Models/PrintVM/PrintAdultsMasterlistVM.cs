using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.PrintVM
{
    public class PrintAdultsMasterlistVM : BaseVM
    {
        public List<HouseholdMember> Adults { get; set; }
    }
}
