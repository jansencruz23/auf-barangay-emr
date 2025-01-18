using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class SummaryVM : BaseVM
    {
        public string Name { get; set; }
        public int TotalForms { get; set; }

        public int HHForms { get; set; }
        public int HHMembers { get; set; }
        public int WRAForms { get; set; }
        public int PregTrackForms { get; set; }
        public int FPForms { get; set; }
        public int PatientForms { get; set; }
        public int VaccinationAppointments { get; set; }
        public int PregForms { get; set; }
        public int PregAppointments { get; set; }
        public int DiabetesRiskForms { get; set; }

        public int TotalDay7 { get; set; }
        public int TotalDay6 { get; set; }
        public int TotalDay5 { get; set; }
        public int TotalDay4 { get; set; }
        public int TotalDay3 { get; set; }
        public int TotalDay2 { get; set; }
        public int TotalDay1 { get; set; }
    }
}
