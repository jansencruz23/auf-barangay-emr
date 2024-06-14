using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class SummaryVM : BaseVM
    {
        public int TotalForms { get; set; }

        public int CreatedHHForms { get; set; }
        public int CreatedHHMembers { get; set; }
        public int CreatedWRAForms { get; set; }
        public int CreatedPregTrackForms { get; set; }
        public int CreatedFPForms { get; set; }
        public int CreatedPatientForms { get; set; }
        public int CreatedVaccinationAppointments { get; set; }
        public int CreatedPregForms { get; set; }
        public int CreatedPregAppointments { get; set; }

        public int ModifiedHHForms { get; set; }
        public int ModifiedHHMembers { get; set; }
        public int ModifiedWRAForms { get; set; }
        public int ModifiedPregTrackForms { get; set; }
        public int ModifiedFPForms { get; set; }
        public int ModifiedPatientForms { get; set; }
        public int ModifiedVaccinationAppointments { get; set; }
        public int ModifiedPregForms { get; set; }
        public int ModifiedPregAppointments { get; set; }

        public int TotalDay7 { get; set; }
        public int TotalDay6 { get; set; }
        public int TotalDay5 { get; set; }
        public int TotalDay4 { get; set; }
        public int TotalDay3 { get; set; }
        public int TotalDay2 { get; set; }
        public int TotalDay1 { get; set; }
    }
}
