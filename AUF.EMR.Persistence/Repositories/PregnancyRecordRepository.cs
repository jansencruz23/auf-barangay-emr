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
    public class PregnancyRecordRepository : GenericRepository<PregnancyRecord>, IPregnancyRecordRepository
    {
        private readonly EMRDbContext _dbContext;

        public PregnancyRecordRepository(EMRDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PregnancyRecord>> GetPregnancyRecordForm(int id)
        {
            var record = await _dbContext.PregnancyRecords
                .AsNoTracking()
                .Include(r => r.Patient)
                    .ThenInclude(p => p.Household)
                .Include(r => r.PregnancyAppointments.Where(a => a.Status))
                .Where(r => r.Status &&
                    r.Patient.Status &&
                    r.Patient.Household.Status &&
                    r.Id == id)
                .ToListAsync();

            return record;
        }

        public async Task<List<PregnancyRecord>> GetPregnancyRecordsWithDetails(string householdNo)
        {
            var records = await _dbContext.PregnancyRecords
                .AsNoTracking()
                .Include(r => r.Patient)
                    .ThenInclude(p => p.Household)
                .Include(r => r.PregnancyAppointments.Where(a => a.Status))
                .Where(r => r.Status &&
                    r.Patient.Status &&
                    r.Patient.Household.Status &&
                    r.Patient.Household.HouseholdNo.Equals(householdNo))
                .ToListAsync();

            return records;
        }

        public async Task<PregnancyRecord> GetPregnancyRecordWithDetails(int id)
        {
            var record = await _dbContext.PregnancyRecords
                .AsNoTracking()
                .Include(r => r.Patient)
                    .ThenInclude(p => p.Household)
                .Include(r => r.PregnancyAppointments.Where(a => a.Status))
                .Where(r => r.Status &&
                    r.Patient.Status &&
                    r.Patient.Household.Status)
                .FirstOrDefaultAsync(r => r.Id == id);

            return record;
        }
    }
}
