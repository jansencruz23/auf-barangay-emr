using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.EditVM
{
    public class EditBarangayVM
    {
        public Barangay Barangay { get; set; }
        public IFormFile? LogoFile { get; set; }
    }
}
