using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.FamilyPlanning;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditFamilyPlanningVM : BaseVM
    {
        public FamilyPlanningRecord FPRecord { get; set; }
        public ClientType ClientType { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public ObstetricalHistory ObstetricalHistory { get; set; }
        public RisksForSTI RisksForSTI { get; set; }
        public RisksForVAW RisksForVAW { get; set; }
        public PhysicalExamination PhysicalExamination { get; set; }

        public List<HouseholdMember> WomenHouseholdMember { get; set; }
    }
}
