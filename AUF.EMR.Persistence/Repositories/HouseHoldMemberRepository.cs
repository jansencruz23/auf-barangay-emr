using AUF.EMR.Application.Constants;
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
    public class HouseholdMemberRepository : GenericRepository<HouseholdMember>, IHouseholdMemberRepository
    {
        private readonly EMRDbContext _dbContext;

        public HouseholdMemberRepository(EMRDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HouseholdMember>> GetHouseholdMembersWithDetails(string houseHoldNo)
        {
            var houseHoldMembers = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status && m.HouseholdNo.Equals(houseHoldNo) && m.Status)
                .ToListAsync();

            return houseHoldMembers;
        }

        public async Task<List<HouseholdMember>> GetHouseholdMembersWithDetails(Guid id, DateTime startDate, DateTime endDate)
        {
            var householdMembers = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.ModifiedById == id &&
                            m.Household.Status &&
                            m.Status &&
                            m.LastModified >= startDate &&
                            m.LastModified <= endDate)
                .ToListAsync();

            return householdMembers;
        }

        public async Task<HouseholdMember> GetHouseholdMemberWithDetails(int id)
        {
            var houseHoldMember = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status && m.Status)
                .FirstOrDefaultAsync(m => m.Id == id);

            return houseHoldMember;
        }

        public async Task<List<HouseholdMember>> GetWRAHouseholdMember(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(WRAAgeRange.WRAStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(WRAAgeRange.WRAEnd);

            var WraMembers = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Status && m.Household.Status &&
                            m.HouseholdNo.Equals(householdNo) &&
                            m.Sex.Equals('F') &&
                            m.Birthday >= startDate &&
                            m.Birthday <= endDate)
                .ToListAsync();

            return WraMembers;
        }
    }
}
