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
    public class PatientRecordService : GenericService<PatientRecord>, IPatientRecordService
    {
        private readonly IPatientRecordRepository _repository;

        public PatientRecordService(IPatientRecordRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<PatientRecord>> GetPatientRecordForm(int id)
        {
            var form = new List<PatientRecord>
            {
                await _repository.GetPatientRecordWithDetails(id)
            };
            return form;
        }

        public async Task<List<PatientRecord>> GetPatientRecordsWithDetails(string householdNo)
        {
            return await _repository.GetPatientRecordsWithDetails(householdNo);
        }

        public async Task<PatientRecord> GetPatientRecordWithDetails(int id)
        {
            return await _repository.GetPatientRecordWithDetails(id);
        }
    }
}
