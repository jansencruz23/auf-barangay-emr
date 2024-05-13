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

        public async Task<List<VaccinationRecord>> GetVaccinationRecordsWithDetails(int id)
        {
            var records = await _dbContext.VaccinationRecords
                .AsNoTracking()
                .Where(r => r.VaccinationAppointmentId == id)
                .ToListAsync();

            return records;
        }
    }
}
