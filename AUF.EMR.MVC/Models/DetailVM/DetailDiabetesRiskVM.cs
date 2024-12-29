using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.DetailVM
{
    public class DetailDiabetesRiskVM : BaseVM
    {
        public DiabetesRisk DiabetesRisk { get; set; } = new();
    }
}
