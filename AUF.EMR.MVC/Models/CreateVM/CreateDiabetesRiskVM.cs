using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.CreateVM
{
    public class CreateDiabetesRiskVM : BaseVM
    {
        public List<HouseholdMember>? MemberList { get; set; } = new();
        public DiabetesRisk DiabetesRisk { get; set; } = new();
        public int HouseholdMemberId { get; set; }
    }
}
