using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public byte[]? Picture { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }

        public string FullName { get => $"{FirstName} {GetMiddleInitial()}. {LastName}"; }
        public string Age { get => $"{GetAge()} years old"; }

        private string GetMiddleInitial()
        {
            if (string.IsNullOrEmpty(MiddleName) || MiddleName.Length < 2)
                return string.Empty;

            return MiddleName.Split(' ').Last()[0].ToString();
        }

        private int GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - Birthday.Year;

            if (Birthday > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        public string LogoBase64String => Picture != null ? Convert.ToBase64String(Picture) : string.Empty;
    }
}
