using AUF.EMR.Application.Constants;
using AUF.EMR.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence.Repositories
{
    public class SumarryRepository : ISummaryRepository
    {
        private readonly EMRDbContext _dbContext;

        public SumarryRepository(EMRDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetCheckedPatientsToday(Guid id, DateTime startDate, DateTime endDate)
        {
            var count = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Status &&
                    m.ModifiedById == id &&
                    m.Household.Status &&
                    m.Birthday >= startDate && m.Birthday <= endDate &&
                    m.LastModified >= DateRange.TodayStart && m.LastModified <= DateRange.TodayEnd)
                .CountAsync();

            return count;
        }
    }
}
