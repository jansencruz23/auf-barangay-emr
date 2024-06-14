using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.Enums;
using AUF.EMR.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence.Repositories
{
    public class SummaryRepository : ISummaryRepository
    {
        private readonly EMRDbContext _dbContext;

        public SummaryRepository(EMRDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetCreatedFormsCount(FormType formType, DateTime startDate, DateTime endDate, Guid userId)
        {
            var count = await _dbContext.RecordLogs
                .AsNoTracking()
                .Where(f => f.ModifiedById.Equals(userId) &&
                    f.EntityName.Equals(formType.ToString()) &&
                    f.Action.Equals("Added") &&
                    f.Timestamp >= startDate &&
                    f.Timestamp <= endDate)
                .CountAsync();

            return count;
        }

        public async Task<int> GetModifiedFormsCount(FormType formType, DateTime startDate, DateTime endDate, Guid userId)
        {
            var count = await _dbContext.RecordLogs
                .AsNoTracking()
                .Where(f => f.ModifiedById.Equals(userId) &&
                    f.EntityName.Equals(formType.ToString()) &&
                    f.Action.Equals("Modified") &&
                    f.Timestamp >= startDate &&
                    f.Timestamp <= endDate)
                .GroupBy(f => new { f.EntityId, f.EntityName })
                .CountAsync();

            return count;
        }

        public async Task<int> GetTotalFormsCount(DateTime startDate, DateTime endDate, Guid userId)
        {
            var createdCount = await _dbContext.RecordLogs
                .AsNoTracking()
                .Where(f => f.ModifiedById.Equals(userId) &&
                    f.Action.Equals("Added") &&
                    !f.EntityName.Equals("PregnancyTrackingHH") &&
                    f.Timestamp >= startDate &&
                    f.Timestamp <= endDate)
                .CountAsync();

            var modifiedCount = await _dbContext.RecordLogs
                .AsNoTracking()
                .Where(f => f.ModifiedById.Equals(userId) &&
                    f.Action.Equals("Modified") &&
                    f.Timestamp >= startDate &&
                    f.Timestamp <= endDate)
                .GroupBy(f => new { f.EntityId, f.EntityName })
                .CountAsync();

            return createdCount + modifiedCount;
        }
    }
}
