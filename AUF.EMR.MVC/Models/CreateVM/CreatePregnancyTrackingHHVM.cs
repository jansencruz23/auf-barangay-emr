using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.CreateVM
{
    public class CreatePregnancyTrackingHHVM : BaseVM
    {
        public PregnancyTrackingHH PregnancyTrackingHH { get; set; }
        public Household Household { get; set; }
    }
}
