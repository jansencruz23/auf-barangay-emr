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
    public class PregnancyRecordService : GenericService<PregnancyRecord>, IPregnancyRecordService
    {
        private readonly IPregnancyRecordRepository _repository;

        public PregnancyRecordService(IPregnancyRecordRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<PregnancyRecord>> GetPregnancyRecordsWithDetails(string householdNo)
        {
            return await _repository.GetPregnancyRecordsWithDetails(householdNo);
        }

        public async Task<PregnancyRecord> GetPregnancyRecordWithDetails(int id)
        {
            return await _repository.GetPregnancyRecordWithDetails(id);
        }
    }
}
