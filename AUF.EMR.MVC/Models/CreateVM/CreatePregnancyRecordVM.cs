using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.CreateVM
{
    public class CreatePregnancyRecordVM : BaseVM
    {
        public List<HouseholdMember>? Women { get; set; }
        public PregnancyRecord PregnancyRecord { get; set; }
    }
}
