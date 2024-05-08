using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence.Seeders
{
    public class VaccineSeeder
    {
        private readonly IVaccineRepository _repository;

        public VaccineSeeder(IVaccineRepository repository)
        {
            _repository = repository;
        }

        public async Task SeedAsync()
        {
            if (await _repository.HasData())
            {
                return;
            }

            var vaccines = new List<Vaccine>
            {
                new Vaccine { Name = "BCG birth dose" },
                new Vaccine { Name = "Hepatitis B birth dose" },
                new Vaccine { Name = "Oral Poliovirus Vaccine" },
                new Vaccine { Name = "Pentavalent Vaccine" },
                new Vaccine { Name = "Measles Containing Vaccines" },
                new Vaccine { Name = "Tetanus Toxoid" },
                new Vaccine { Name = "Pneumococcal Conjugate Vaccine 13" }
            };

            await _repository.AddRange(vaccines);
        }
    }
}