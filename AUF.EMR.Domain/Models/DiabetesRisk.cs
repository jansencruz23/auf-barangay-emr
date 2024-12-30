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
    public bool IsPhysicallyActive { get; set; } = true;// true = 0pts, false = 2pts
    public bool EatsVegetablesEveryDay { get; set; } = true; // true = 0pts, false = 2pts
    public bool TakingHighBloodPressureMedication { get; set; } // true = 2pts, false = 0pts
    public bool HasHighBloodGlucose { get; set; } // true = 5pts, false = 0pts

    [Required(ErrorMessage = "The Family Diabetes History field is required.")]
    [Display(Name = "Family Diabetes History")]
    public FamilyWithDiabetesRiskPoints? FamilyWithDiabetesRiskPoints { get; set; }
    public int TotalScore => CalculateTotalRiskScore();
    public string Risk => GetRisk();

    private int CalculateTotalRiskScore()
    {
        var totalRiskScore = 0;

        totalRiskScore += (int)AgeRiskPoints;
        totalRiskScore += (int)BmiRiskPoints;

        if (WaistCircumferenceMenRiskPoints.HasValue)
        {
            totalRiskScore += (int)WaistCircumferenceMenRiskPoints;
        }

        if (WaistCircumferenceWomenRiskPoints.HasValue)
        {
            totalRiskScore += (int)WaistCircumferenceWomenRiskPoints;
        }

        totalRiskScore += IsPhysicallyActive ? 0 : 2;
        totalRiskScore += EatsVegetablesEveryDay ? 0 : 1;
        totalRiskScore += TakingHighBloodPressureMedication ? 2 : 0;
        totalRiskScore += HasHighBloodGlucose ? 5 : 0;
        totalRiskScore += (int)FamilyWithDiabetesRiskPoints;

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
}
