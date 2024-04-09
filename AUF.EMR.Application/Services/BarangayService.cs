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
    public class BarangayService : GenericService<Barangay>, IBarangayService
    {
        private readonly IBarangayRepository _repository;

        public BarangayService(IBarangayRepository repository) : 
            base(repository)
        {
            _repository = repository;
        }

        public async Task<Barangay> GetBarangay()
        {
            return await _repository.GetBarangay();
        }

        public async Task<bool> HasData()
        {
            return await _repository.HasData();
        }
    }
}
