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
    public class PregnancyTrackingService : GenericService<PregnancyTracking>, IPregnancyTrackingService
    {
        private readonly IPregnancyTrackingRepository _repository;

        public PregnancyTrackingService(IPregnancyTrackingRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<PregnancyTracking>> GetPregnancyTrackingListWithDetails(string householdNo)
        {
            return await _repository.GetPregnancyTrackingListWithDetails(householdNo);
        }

        public async Task<PregnancyTracking> GetPregnancyTrackingWithDetails(int id)
        {
            return await _repository.GetPregnancyTrackingWithDetails(id);
        }
    }
}
