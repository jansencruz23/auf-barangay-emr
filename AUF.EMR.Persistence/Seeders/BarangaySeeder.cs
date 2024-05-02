using AUF.EMR.Application.Contracts.Persistence;
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
        private readonly IBarangayRepository _repository;

        public BarangaySeeder(IBarangayRepository repository)
        {
            _repository = repository;
        }

        public async Task SeedAsync()
        {
            if (await _repository.HasData())
            {
                return;
            }

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

            await _repository.Add(barangay);
        }
    }
}
