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
    public class VaccinationRecordService : GenericService<VaccinationRecord>, IVaccinationRecordService
    {
        private readonly IVaccinationRecordRepository _repository;

        public VaccinationRecordService(IVaccinationRecordRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public async Task DeleteVaccinationRecord(int vaccinationAppointmendId, int vaccineId)
        {
            await _repository.DeleteVaccinationRecord(vaccinationAppointmendId, vaccineId);
        }

        public async Task<List<VaccinationRecord>> GetVaccinationRecordsWithDetails(int id)
        {
            return await _repository.GetVaccinationRecordsWithDetails(id);
        }
    }
}
