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
    public class PregnancyTrackingRepository : GenericRepository<PregnancyTracking>, IPregnancyTrackingRepository
    {
        private readonly EMRDbContext _dbContext;

        public PregnancyTrackingRepository(EMRDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PregnancyTracking>> GetPregnancyTrackingListWithDetails(string householdNo)
        {
            var pregnancyLists = await _dbContext.PregnancyTrackings
                .AsNoTracking()
                .Include(p => p.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status && 
                    p.HouseholdMember.Household.HouseholdNo.Equals(householdNo) &&
                    p.HouseholdMember.Household.Status &&
                    p.HouseholdMember.Status)
                .ToListAsync();

            return pregnancyLists;
        }

        public async Task<PregnancyTracking> GetPregnancyTrackingWithDetails(int id)
        {
            var pregnantWoman = await _dbContext.PregnancyTrackings
                .AsNoTracking()
                .Include(p => p.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status &&
                    p.HouseholdMember.Status &&
                    p.HouseholdMember.Household.Status)
                .FirstOrDefaultAsync(p => p.Id == id);

            return pregnantWoman;
        }

        public async Task<List<HouseholdMember>> GetPregnantHouseholdMembers(string householdNo, DateTime startDate, DateTime endDate)
        {
            var pregnantMembers = await _dbContext.PregnancyTrackings
                .AsNoTracking()
                .Include(p => p.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status && 
                    p.HouseholdMember.Household.HouseholdNo.Equals(householdNo) &&
                    p.HouseholdMember.Household.Status &&
                    p.HouseholdMember.Status)
                .Where(p => p.PregnancyOutcome == null)
                .Where(p => p.HouseholdMember.Birthday >= startDate && p.HouseholdMember.Birthday <= endDate)
                .Select(p => p.HouseholdMember)
                .ToListAsync();

            return pregnantMembers;
        }

        public async Task<List<HouseholdMember>> GetPregnantTrackingMembers(string householdNo)
        {
            var members = await _dbContext.PregnancyTrackings
                .AsNoTracking()
                .Include(p => p.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status &&
                    p.HouseholdMember.Household.HouseholdNo.Equals(householdNo) &&
                    p.HouseholdMember.Status &&
                    p.HouseholdMember.Household.Status)
                .Select(p => p.HouseholdMember)
                .ToListAsync();

            return members;
        }
    }
}
