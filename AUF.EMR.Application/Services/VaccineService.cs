using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Services
{
    public class VaccineService : GenericService<Vaccine>, IVaccineService
    {
        private readonly IVaccineRepository _repository;

        public VaccineService(IVaccineRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> HasData()
        {
            return await _repository.HasData();
        }
    }
}
