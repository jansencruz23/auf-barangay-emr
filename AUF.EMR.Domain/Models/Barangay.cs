using AUF.EMR.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class Barangay : BaseDomainEntity
    {
        public string BarangayName { get; set; }
        public byte[]? Logo { get; set; }
        public string Street { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public string Region { get; set; }
        public string? ContactNo { get; set; }
        public string BarangayHealthStation { get; set; }
        public string RuralHealthUnit { get; set; }
        public string? Description { get; set; }

        public string LogoBase64String => Logo != null ? Convert.ToBase64String(Logo) : string.Empty;
    }
}
