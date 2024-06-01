using AUF.EMR.Domain.Models.Identity;
using AUF.EMR.MVC.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace AUF.EMR.MVC.Models.EditVM
{
    public class ResetPasswordVM : BaseVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
