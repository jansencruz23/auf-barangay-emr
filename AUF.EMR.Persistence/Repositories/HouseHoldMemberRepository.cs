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
                .Where(m => m.Household.Status)
                .Where(m => m.HouseholdNo.Equals(houseHoldNo) && m.Status)
                .ToListAsync();

            return houseHoldMembers;
        }

        public async Task<HouseholdMember> GetHouseholdMemberWithDetails(int id)
        {
            var houseHoldMember = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status)
                .Where(m => m.Status)
                .FirstOrDefaultAsync(m => m.Id == id);

            return houseHoldMember;
        }
    }
}
