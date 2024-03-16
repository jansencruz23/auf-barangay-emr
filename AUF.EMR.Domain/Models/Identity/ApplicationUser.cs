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
        public string MiddleName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
    }
}
