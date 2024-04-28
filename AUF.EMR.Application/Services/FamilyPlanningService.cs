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
    public class FamilyPlanningService : GenericService<FamilyPlanningRecord>, IFamilyPlanningService
    {
        private readonly IFamilyPlanningRepository _repository;

        public FamilyPlanningService(IFamilyPlanningRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<FamilyPlanningRecord> GetFPRecordWithDetails(int id)
        {
            return await _repository.GetFPRecordWithDetails(id);
        }

        public async Task<List<FamilyPlanningRecord>> GetFPRecordsWithDetails(string householdNo)
        {
            return await _repository.GetFPRecordsWithDetails(householdNo);
        }
    }
}
