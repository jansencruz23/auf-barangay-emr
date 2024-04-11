using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.PrintVM
{
    public class PrintChildrenMasterlistVM : BasePrintListVM
    {
        public List<HouseholdMember> Newborns { get; set; }
        public List<HouseholdMember> Infants { get; set; }
        public List<HouseholdMember> UnderFive { get; set; }
        public List<HouseholdMember> SchoolAged { get; set; }
        public List<HouseholdMember> Adolescents { get; set; }
    }
}
