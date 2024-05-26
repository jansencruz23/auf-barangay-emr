using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services.Common;
using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.FamilyPlanning;
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

        public async Task<FamilyPlanningRecord> AddFamilyPlanning(FamilyPlanningRecord fpRecord)
        {
            return await _repository.AddFamilyPlanning(fpRecord);
        }

        public async Task UpdateFamilyPlanning(FamilyPlanningRecord fpRecord)
        {
            await _repository.UpdateFamilyPlanning(fpRecord);
        }

        public async Task<List<FamilyPlanningRecord>> GetFamilyPlanningForm(int id)
        {
            var form = new List<FamilyPlanningRecord>
            {
                await _repository.GetFPRecordWithDetails(id)
            };
            return form;
        }

        public async Task<List<ClientType>> GetClientTypeForm(int id)
        {
            var form = new List<ClientType>()
            {
                (await GetFPRecordWithDetails(id)).ClientType
            };
            return form;
        }

        public async Task<List<MedicalHistory>> GetMedicalHistoryForm(int id)
        {
            var form = new List<MedicalHistory>()
            {
                (await GetFPRecordWithDetails(id)).MedicalHistory
            };
            return form;
        }

        public async Task<List<ObstetricalHistory>> GetObstetricalHistoryForm(int id)
        {
            var form = new List<ObstetricalHistory>()
            {
                (await GetFPRecordWithDetails(id)).ObstetricalHistory
            };
            return form;
        }
    }
}
