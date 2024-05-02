using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class WRAListVM : BaseVM
    {
        public List<WomanOfReproductiveAge> WRAs { get; set; }
    }
}
