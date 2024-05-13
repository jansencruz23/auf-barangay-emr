using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditPregnancyRecordVM : BaseVM
    {
        public PregnancyRecord PregnancyRecord { get; set; }
        public List<HouseholdMember>? Women { get; set; }
    }
}
