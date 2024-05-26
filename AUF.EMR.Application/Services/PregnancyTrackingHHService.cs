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
    public class PregnancyTrackingHHService : GenericService<PregnancyTrackingHH>, IPregnancyTrackingHHService
    {
        private readonly IPregnancyTrackingHHRepository _repository;

        public PregnancyTrackingHHService(IPregnancyTrackingHHRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<PregnancyTrackingHH> GetPregnancyTrackingHHWithDetails(int id)
        {
            return await _repository.GetPregnancyTrackingHHWithDetails(id);
        }

        public async Task<PregnancyTrackingHH> GetPregnancyTrackingHHWithDetails(string householdNo)
        {
            return await _repository.GetPregnancyTrackingHHWithDetails(householdNo);
        }

        public async Task<List<PregnancyTrackingHH>> GetPregnancyTrackingsHHWithDetails(string householdNo)
        {
            var list = new List<PregnancyTrackingHH>
            {
                await _repository.GetPregnancyTrackingHHWithDetails(householdNo)
            };

            return list;
        }
    }
}
