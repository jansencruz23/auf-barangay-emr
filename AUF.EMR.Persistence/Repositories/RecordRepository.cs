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

        public async Task<IReadOnlyList<RecordLog>> GetRecords(DateTime startTime, DateTime endTime)
        {
            var records = await _dbContext.RecordLogs
                .AsNoTracking()
                .Where(r => r.Timestamp >= startTime && r.Timestamp <= endTime)
                .ToListAsync();

            return records;
        }
    }
}
