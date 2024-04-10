using AUF.EMR.Application.Constants;
using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private readonly EMRDbContext _dbContext;

        public RecordRepository(EMRDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<RecordLog>> GetRecordsToday(Guid id)
        {
            var count = await _dbContext.RecordLogs
                .AsNoTracking()
                .Where(r => r.Timestamp >= DateRange.TodayStart && 
                    r.Timestamp <= DateRange.TodayEnd &&
                    r.ModifiedById == id)
                .ToListAsync();

            return count;
        }

        public async Task<IReadOnlyList<RecordLog>> GetRecords(DateTime startDate, DateTime endDate)
        {
            var records = await _dbContext.RecordLogs
                .AsNoTracking()
                .Where(r => r.Timestamp >= startDate && r.Timestamp <= endDate)
                .ToListAsync();

            return records;
        }
    }
}
