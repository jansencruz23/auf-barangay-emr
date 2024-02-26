using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models
{
    public class CreateMasterlistChildrenVM
    {
        public string HouseholdNo { get; set; }
        public MasterlistChildren MasterlistChildren { get; set; } = new();
        public HouseholdMember HouseholdMember { get; set; }
        public List<HouseholdMember>? HouseholdMembers { get; set; }
    }
}
