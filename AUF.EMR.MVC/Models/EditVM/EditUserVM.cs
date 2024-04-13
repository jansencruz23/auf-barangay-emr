using AUF.EMR.Domain.Models.Identity;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditUserVM : BaseVM
    {
        public ApplicationUser User { get; set; }
    }
}
