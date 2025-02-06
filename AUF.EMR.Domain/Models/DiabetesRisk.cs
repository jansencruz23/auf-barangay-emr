using AUF.EMR.Domain.Models.Common;
using AUF.EMR.Domain.Models.Enums.DiabetesRisk;
using System.ComponentModel.DataAnnotations;

namespace AUF.EMR.Domain.Models;

public class DiabetesRisk : BaseDomainEntity
{
    [Display(Name = "Household Member")]
    public int HouseholdMemberId { get; set; }
    public HouseholdMember? HouseholdMember { get; set; }

    [Required(ErrorMessage = "The Age field is required.")]
    [Display(Name = "Age")]
    public AgeRiskPoints? AgeRiskPoints { get; set; }

    [Required(ErrorMessage = "The BMI field is required.")]
    [Display(Name = "BMI")]
    public BmiRiskPoints? BmiRiskPoints { get; set; }

    [Display(Name = "Waist Circumference")]
    public WaistCircumferenceMenRiskPoints? WaistCircumferenceMenRiskPoints { get; set; }

    [Display(Name = "Waist Circumference")]
    public WaistCircumferenceWomenRiskPoints? WaistCircumferenceWomenRiskPoints { get; set; }

    [Required(ErrorMessage = "The Physical Activity field is required.")]
    [Display(Name = "Physical Activity")]
    public bool? IsPhysicallyActive { get; set; } // true = 0pts, false = 2pts

    [Required(ErrorMessage = "The Healthy Food Intake field is required.")]
    [Display(Name = "Healthy Food Intake")]
    public bool? EatsVegetablesEveryDay { get; set; }  // true = 0pts, false = 2pts

    [Required(ErrorMessage = "The High Blood Pressure field is required.")]
    [Display(Name = "High Blood Pressure")]
    public bool? TakingHighBloodPressureMedication { get; set; } // true = 2pts, false = 0pts

    [Required(ErrorMessage = "The High Blood Glucose field is required.")]
    [Display(Name = "High Blood Glucose")]
    public bool? HasHighBloodGlucose { get; set; } // true = 5pts, false = 0pts

    [Required(ErrorMessage = "The Family Diabetes History field is required.")]
    [Display(Name = "Family Diabetes History")]
    public FamilyWithDiabetesRiskPoints? FamilyWithDiabetesRiskPoints { get; set; }
    public int TotalScore => CalculateTotalRiskScore();
    public string Risk => GetRisk();

    private int CalculateTotalRiskScore()
    {
        var totalRiskScore = 0;

        totalRiskScore += AgeRiskPoints.HasValue ? (int)AgeRiskPoints : 0;
        totalRiskScore += BmiRiskPoints.HasValue ? (int)BmiRiskPoints : 0;
        totalRiskScore += WaistCircumferenceMenRiskPoints.HasValue ? (int)WaistCircumferenceMenRiskPoints : 0;
        totalRiskScore += WaistCircumferenceWomenRiskPoints.HasValue ? (int)WaistCircumferenceWomenRiskPoints : 0;
        totalRiskScore += FamilyWithDiabetesRiskPoints.HasValue ? (int)FamilyWithDiabetesRiskPoints : 0;

        totalRiskScore += IsPhysicallyActive.HasValue ? (IsPhysicallyActive.Value ? 0 : 2) : 0;
        totalRiskScore += EatsVegetablesEveryDay.HasValue ? (EatsVegetablesEveryDay.Value ? 0 : 1) : 0;
        totalRiskScore += TakingHighBloodPressureMedication.HasValue ? (TakingHighBloodPressureMedication.Value ? 2 : 0) : 0;
        totalRiskScore += HasHighBloodGlucose.HasValue ? (HasHighBloodGlucose.Value ? 5 : 0) : 0;

        return totalRiskScore;
    }

    private string GetRisk()
    {
        return TotalScore switch
        {
            < 7 => "Low",
            >= 7 and <= 11 => "Slightly elevated",
            >= 12 and <= 14 => "Moderate",
            >= 15 and <= 20 => "High",
            > 20 => "Very high"
        };
    }

    // Props for printing
    // Age risk
    public bool? IsUnder45 => AgeRiskPoints == Enums.DiabetesRisk.AgeRiskPoints.Under45;
    public bool? Is45To54 => AgeRiskPoints == Enums.DiabetesRisk.AgeRiskPoints.Age45To54;
    public bool? Is55To64 => AgeRiskPoints == Enums.DiabetesRisk.AgeRiskPoints.Age55To64;
    public bool? IsOver64 => AgeRiskPoints == Enums.DiabetesRisk.AgeRiskPoints.Over64;

    // BMI risk
    public bool? IsLower25 => BmiRiskPoints == Enums.DiabetesRisk.BmiRiskPoints.Under25;
    public bool? Is25To30 => BmiRiskPoints == Enums.DiabetesRisk.BmiRiskPoints.Bmi25To30;
    public bool? IsOver30 => BmiRiskPoints == Enums.DiabetesRisk.BmiRiskPoints.Over30;

    // Waist circumference risk
    public bool? IsMenUnder94 => WaistCircumferenceMenRiskPoints == Enums.DiabetesRisk.WaistCircumferenceMenRiskPoints.Under94 && HouseholdMember?.Sex == 'M';
    public bool? IsMen94To102 => WaistCircumferenceMenRiskPoints == Enums.DiabetesRisk.WaistCircumferenceMenRiskPoints.Between94And102 && HouseholdMember?.Sex == 'M';
    public bool? IsMenOver102 => WaistCircumferenceMenRiskPoints == Enums.DiabetesRisk.WaistCircumferenceMenRiskPoints.Over102 && HouseholdMember?.Sex == 'M';
    public bool? IsWomenUnder80 => WaistCircumferenceWomenRiskPoints == Enums.DiabetesRisk.WaistCircumferenceWomenRiskPoints.Under80 && HouseholdMember?.Sex == 'F';
    public bool? IsWomen80To88 => WaistCircumferenceWomenRiskPoints == Enums.DiabetesRisk.WaistCircumferenceWomenRiskPoints.Between80And88 && HouseholdMember?.Sex == 'F';
    public bool? IsWomenOver88 => WaistCircumferenceWomenRiskPoints == Enums.DiabetesRisk.WaistCircumferenceWomenRiskPoints.Over88 && HouseholdMember?.Sex == 'F';

    // Family with diabetes risk
    public bool? IsNoFamilyDiabetes => FamilyWithDiabetesRiskPoints == Enums.DiabetesRisk.FamilyWithDiabetesRiskPoints.No;
    public bool? IsExtendedFamilyDiabetes => FamilyWithDiabetesRiskPoints == Enums.DiabetesRisk.FamilyWithDiabetesRiskPoints.ExtendedFamily;
    public bool? IsImmediateFamilyDiabetes => FamilyWithDiabetesRiskPoints == Enums.DiabetesRisk.FamilyWithDiabetesRiskPoints.ImmediateFamily;
}
