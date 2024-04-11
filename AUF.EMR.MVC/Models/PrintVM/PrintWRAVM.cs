using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace AUF.EMR.MVC.Models.PrintVM
{
    public class PrintWRAVM : BasePrintListVM
    {
        public int Quarter { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatePrepared { get; set; }
        public List<WomanOfReproductiveAge> WRAs { get; set; }
    }
}
