using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.Common
{
    public class BasePrintListVM : BaseVM
    {
        public Barangay Barangay { get; set; }
        public string RequestUrl { get; set; }
        public string Midwife { get; set; }
    }
}
