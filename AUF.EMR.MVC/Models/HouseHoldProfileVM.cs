using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models
{
    public class HouseHoldProfileVM
    {
        public HouseHold HouseHold { get; set; } = new();
        public HouseHoldMember HouseHoldMember { get; set; }
        public List<HouseHoldMember> HouseHoldMembers { get; set; } = new();
    }
}
