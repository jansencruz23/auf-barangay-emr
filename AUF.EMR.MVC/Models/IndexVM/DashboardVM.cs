using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class DashboardVM : BaseVM
    {
        public string Barangay { get; set; }
        public int HouseholdCount { get; set; } 
        public int HouseholdMemberCount { get; set; } 
        public int NewbornCount { get; set; } 
        public int InfantCount { get; set; } 
        public int UnderFiveCount { get; set; } 
        public int SchoolAgedCount { get; set; } 
        public int AdolescentsCount { get; set; } 
        public int AdultCount { get; set; } 
        public int SeniorCount { get; set; }
        public int PregnantCount { get; set; }
        public int WRAFormCount { get; set; }
        public int PregTrackCount { get; set; }
        public int FamilyPlanningFormsCount { get; set; }
        public int PatientRecordCount { get; set; }
        public int PregnancyRecordCount { get; set; }
        public int DiabetesRiskRecordCount { get; set; }
        public int? HHCount1 { get; set; }
        public int? HHCount2 { get; set; }
        public int? HHCount3 { get; set; }
        public int? HHCount4 { get; set; }
        public int? HHCount5 { get; set; }
        public int? HHCount6 { get; set; }
        public int? HHCount7 { get; set; }
    }
}
