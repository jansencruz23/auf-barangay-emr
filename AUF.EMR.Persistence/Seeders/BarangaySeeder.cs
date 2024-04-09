using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence.Seeders
{
    public class BarangaySeeder
    {
        private readonly IBarangayService _barangayService;

        public BarangaySeeder(IBarangayService barangayService)
        {
            _barangayService = barangayService;
        }

        public async Task SeedAsync()
        {
            if (!await _barangayService.HasData())
            {
                var barangay = new Barangay
                {
                    BarangayName = "Ninoy Aquino",
                    Logo = null,
                    BarangayHealthStation = "",
                    ContactNo = "09123456789",
                    Street = "Marisol",
                    Municipality = "Angeles City",
                    Province = "Pampanga",
                    Region = "III",
                    RuralHealthUnit = "",
                    Description = ""
                };

                await _barangayService.Add(barangay);
            }
        }
    }
}
