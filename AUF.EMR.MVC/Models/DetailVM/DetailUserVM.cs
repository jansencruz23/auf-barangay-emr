using AUF.EMR.Domain.Models.Identity;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.DetailVM
{
    public class DetailUserVM : BaseVM
    {
        public ApplicationUser User { get; set; }
    }
}
