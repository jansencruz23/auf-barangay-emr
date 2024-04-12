using AUF.EMR.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly EMRDbContext _dbContext;

        public DashboardRepository(EMRDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetHouseholdCount()
        {
            var count = await _dbContext.HouseHolds
                .AsNoTracking()
                .Where(h => h.Status)
                .CountAsync();

            return count;
        }

        public async Task<int> GetHouseholdMemberCount()
        {
            var count = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Where(h => h.Status)
                .CountAsync();

            return count;
        }

        public async Task<int> GetHouseholdMemberCount(string householdNo)
        {
            var count = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Where(m => m.Status &&
                    m.HouseholdNo.Equals(householdNo))
                .CountAsync();

            return count;
        }

        public async Task<int> GetMemberByAgeCount(DateTime startDate, DateTime endDate)
        {
            var count = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Where(m => m.Status &&
                    m.Birthday >= startDate &&
                    m.Birthday <= endDate)
                .CountAsync();

            return count;
        }

        public async Task<int> GetMemberByAgeCount(string householdNo, DateTime startDate, DateTime endDate)
        {
            var count = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Where(m => m.Status &&
                    m.HouseholdNo.Equals(householdNo) &&
                    m.Birthday >= startDate &&
                    m.Birthday <= endDate)
                .CountAsync();

            return count;
        }
    }
}
