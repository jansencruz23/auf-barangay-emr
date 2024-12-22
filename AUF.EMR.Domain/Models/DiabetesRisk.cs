using AUF.EMR.Domain.Models.Common;
using AUF.EMR.Domain.Models.Enums.DiabetesRisk;

namespace AUF.EMR.Domain.Models;

public class DiabetesRisk : BaseDomainEntity
{
    public int HouseholdMemberId { get; set; }
    public HouseholdMember HouseholdMember { get; set; }
    public int Age { get; set; }
    public AgeRiskPoints AgeRiskPoints => MapAgeRisk();
    public double? HeightInCm { get; set; }
    public double? WeightInKg { get; set; }
    public double Bmi { get; private set; }
    public BmiRiskPoints BmiRiskPoints => MapBmiRisk();
    public WaistCircumferenceMenRiskPoints WaistCircumferenceMenRiskPoints => MapWaistCircumferenceMenRiskPoints();
    public WaistCircumferenceWomenRiskPoints WaistCircumferenceWomenRiskPoints => MapWaistCircumferenceWomenRiskPoints();
    public double? WaistCircumferenceMen { get; set; }
    public double? WaistCircumferenceWomen { get; set; }
    public bool IsPhysicallyActive { get; set; } // true = 0pts, false = 2pts
    public bool EatsVegetablesEveryDay { get; set; } // true = 0pts, false = 2pts
    public bool TakingHighBloodPressureMedication { get; set; } // true = 2pts, false = 0pts
    public bool HasHighBloodGlucose { get; set; } // true = 5pts, false = 0pts
    public FamilyWithDiabetesRiskPoints FamilyWithDiabetesRiskPoints { get; set; }


    private AgeRiskPoints MapAgeRisk()
    {
        return Age switch
        {
            < 45 => AgeRiskPoints.Under45,
            >= 45 and < 55 => AgeRiskPoints.Age45To54,
            >= 55 and < 65 => AgeRiskPoints.Age55To64,
            >= 65 => AgeRiskPoints.Over65
        };
    }

    public void CalculateBMI()
    {
        if (!HeightInCm.HasValue || !WeightInKg.HasValue)
        {
            Bmi = 0;
        }

        Bmi = WeightInKg.Value / Math.Pow(HeightInCm.Value / 100, 2);
    }

    private BmiRiskPoints MapBmiRisk()
    {
        return Bmi switch
        {
            < 25 => BmiRiskPoints.Under25,
            >= 25 and <= 30 => BmiRiskPoints.Bmi25To30,
            > 30 => BmiRiskPoints.Over30,
            _ => throw new NotImplementedException()
        };
    }

    private WaistCircumferenceMenRiskPoints MapWaistCircumferenceMenRiskPoints()
    {
        return WaistCircumferenceMen switch
        {
            < 94 => WaistCircumferenceMenRiskPoints.Under94,
            >= 94 and <= 102 => WaistCircumferenceMenRiskPoints.Between94And102,
            > 102 => WaistCircumferenceMenRiskPoints.Over102,
            _ => throw new NotImplementedException()
        };
    }

    private WaistCircumferenceWomenRiskPoints MapWaistCircumferenceWomenRiskPoints()
    {
        return WaistCircumferenceWomen switch
        {
            < 80 => WaistCircumferenceWomenRiskPoints.Under80,
            >= 80 and <= 88 => WaistCircumferenceWomenRiskPoints.Between80And88,
            > 88 => WaistCircumferenceWomenRiskPoints.Over88,
            _ => throw new NotImplementedException()
        };
    }

    public int CalculateTotalRiskScore()
    {
        var totalRiskScore = 0;

        totalRiskScore += (int)AgeRiskPoints;
        totalRiskScore += (int)BmiRiskPoints;

        if (WaistCircumferenceMen.HasValue)
        {
            totalRiskScore += (int)WaistCircumferenceMenRiskPoints;
        }

        if (WaistCircumferenceWomen.HasValue)
        {
            totalRiskScore += (int)WaistCircumferenceWomenRiskPoints;
        }

        totalRiskScore += IsPhysicallyActive ? 0 : 2;
        totalRiskScore += EatsVegetablesEveryDay ? 0 : 2;
        totalRiskScore += TakingHighBloodPressureMedication ? 2 : 0;
        totalRiskScore += HasHighBloodGlucose ? 5 : 0;
        totalRiskScore += (int)FamilyWithDiabetesRiskPoints;

        return totalRiskScore;
    }
}
