using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditDiabetesRiskVM : BaseVM
    {
        public List<HouseholdMember>? MemberList { get; set; } = new();
        public DiabetesRisk DiabetesRisk { get; set; } = new();

        [Display(Name = "Height")]
        public double? HeightInCm { get; set; }

        [Display(Name = "Weight")]
        public double? WeightInKg { get; set; }

        [Display(Name = "BMI")]
        public double? Bmi { get; set; }
    }
}
