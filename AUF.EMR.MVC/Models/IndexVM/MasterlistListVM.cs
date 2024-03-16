using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class MasterlistListVM
    {
        public List<HouseholdMember> HouseholdMembers { get; set; }
        public string RequestUrl { get; set; }
    }
}
