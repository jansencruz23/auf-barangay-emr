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
    public class PatientRecordRepository : GenericRepository<PatientRecord>, IPatientRecordRepository
    {
        private readonly EMRDbContext _dbContext;

        public PatientRecordRepository(EMRDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PatientRecord>> GetPatientRecordsWithDetails(string householdNo)
        {
            var records = await _dbContext.PatientRecords
                .AsNoTracking()
                .Include(p => p.VaccinationAppointments)
                    .ThenInclude(v => v.VaccinationRecords)
                        .ThenInclude(r => r.Vaccine)
                .Include(p => p.Patient)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status &&
                    p.Patient.Household.HouseholdNo.Equals(householdNo) &&
                    p.Patient.Status &&
                    p.Patient.Household.Status)
                .ToListAsync();

            return records;
        }

        public async Task<PatientRecord> GetPatientRecordWithDetails(int id)
        {
            var record = await _dbContext.PatientRecords
                .AsNoTracking()
                .Include(p => p.Patient)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status &&
                    p.Patient.Household.Status &&
                    p.Patient.Status)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (record != null)
            {
                record.VaccinationAppointments = await _dbContext.VaccinationAppointments
                    .Where(a => a.PatientRecordId == id && a.Status)
                    .Include(v => v.VaccinationRecords)
                        .ThenInclude(r => r.Vaccine)
                    .Include(v => v.PatientRecord)
                        .ThenInclude(p => p.Patient)
                            .ThenInclude(p => p.Household)
                    .OrderByDescending(a => a.VaccinationDate)
                    .ToListAsync();
            }

            return record;
        }
    }
}
