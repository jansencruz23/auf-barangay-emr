using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Domain.Models;
using AUF.EMR.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence.Repositories
{
    public class VaccinationRecordRepository : GenericRepository<VaccinationRecord>, IVaccinationRecordRepository
    {
        private readonly EMRDbContext _dbContext;

        public VaccinationRecordRepository(EMRDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteVaccinationRecord(int vaccinationAppointmendId, int vaccineId)
        {
            var record = await _dbContext.VaccinationRecords
                .FirstOrDefaultAsync(r => r.VaccinationAppointmentId == vaccinationAppointmendId &&
                    r.VaccineId == vaccineId);

            await Delete(record);
        }

        public async Task<List<VaccinationAppointment>> GetVaccinationAppointmentsForm(int appointmentId)
        {
            var records = await _dbContext.VaccinationRecords
                .AsNoTracking()
                .Include(v => v.Vaccine)
                .Include(v => v.VaccinationAppointment)
                    .ThenInclude(a => a.PatientRecord)
                .Where(v => v.VaccinationAppointment.PatientRecordId == appointmentId 
                    && v.VaccinationAppointment.Status)
                .Select(v => v.VaccinationAppointment)
                .ToListAsync();

            return records;
        }

        public async Task<List<VaccinationRecord>> GetVaccinationRecordsForm(int appointmentId)
        {
            var records = await _dbContext.VaccinationRecords
                .AsNoTracking()
                .Include(v => v.Vaccine)
                .Include(v => v.VaccinationAppointment)
                    .ThenInclude(a => a.PatientRecord)
                .Where(v => v.VaccinationAppointment.PatientRecordId == appointmentId)
                .ToListAsync();

            return records;
        }

        public async Task<List<VaccinationRecord>> GetVaccinationRecordsWithDetails(int id)
        {
            var records = await _dbContext.VaccinationRecords
                .AsNoTracking()
                .Include(v => v.Vaccine)
                .Include(v => v.VaccinationAppointment)
                .Where(r => r.VaccinationAppointmentId == id)
                .ToListAsync();

            return records;
        }

        public async Task<List<VaccinationRecord>> GetVaccineRecordsForm(int appointmentId)
        {
            var records = await _dbContext.VaccinationRecords
                .AsNoTracking()
                .Include(v => v.Vaccine)
                .Include(v => v.VaccinationAppointment)
                    .ThenInclude(a => a.PatientRecord)
                .Where(v => v.VaccinationAppointment.PatientRecordId == appointmentId
                    && v.VaccinationAppointment.Status)
                .ToListAsync();

            return records;
        }

        public async Task<List<Vaccine>> GetVaccinesForm(int appointmentId)
        {
            var records = await _dbContext.VaccinationRecords
                .AsNoTracking()
                .Include(v => v.Vaccine)
                .Include(v => v.VaccinationAppointment)
                    .ThenInclude(a => a.PatientRecord)
                .Where(v => v.VaccinationAppointment.PatientRecordId == appointmentId
                    && v.VaccinationAppointment.Status)
                .Select(v => v.Vaccine)
                .ToListAsync();

            return records;
        }
    }
}
