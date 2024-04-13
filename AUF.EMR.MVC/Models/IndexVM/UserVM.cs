using AUF.EMR.Domain.Models.Identity;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class UserVM : BaseVM
    {
        public IList<ApplicationUser> Users { get; set; }
    }
}
