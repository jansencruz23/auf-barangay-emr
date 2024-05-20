using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.Common
{
    public class BaseVM
    {
        public string? RequestUrl { get; set; }
        public string? ErrorMessage { get; set; }
        public string? HouseholdNo { get; set; }
    }
}
