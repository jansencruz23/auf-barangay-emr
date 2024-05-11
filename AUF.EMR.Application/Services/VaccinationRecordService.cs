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

        public async Task<List<VaccinationRecord>> AddVaccinationRecords(int vaccinationAppointmentId, List<Vaccine> vaccines)
        {
            var vaccinationRecords = new List<VaccinationRecord>();

            foreach (var vaccine in vaccines)
            {
                var vaccinationRecord = new VaccinationRecord
                {
                    VaccinationAppointmentId = vaccinationAppointmentId,
                    VaccineId = vaccine.Id
                };
                vaccinationRecords.Add(vaccinationRecord);
            }

            await _repository.AddRange(vaccinationRecords);
            return vaccinationRecords;
        }

        public async Task DeleteVaccinationRecords(int vaccinationAppointmentId, List<Vaccine> vaccines)
        {
            foreach (var vaccine in vaccines)
            {
                await _repository.DeleteVaccinationRecord(vaccinationAppointmentId, vaccine.Id);
            }
        }

        public async Task<List<VaccinationRecord>> GetVaccinationRecordsWithDetails(int id)
        {
            return await _repository.GetVaccinationRecordsWithDetails(id);
        }
    }
}
