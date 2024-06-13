using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.DetailVM
{
    public class DetailHouseholdMemberVM : BaseVM
    {
        public HouseholdMember HouseholdMember { get; set; }
        public List<string> FirstClassificationList { get; set; }
        public List<string> SecondClassificationList { get; set; }
        public List<string> ThirdClassificationList { get; set; }
        public List<string> FourthClassificationList { get; set; }
    }
}
