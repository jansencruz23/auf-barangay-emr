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
    public class HouseHoldMemberRepository : GenericRepository<HouseHoldMember>, IHouseHoldMemberRepository
    {
        private readonly EMRDbContext _dbContext;

        public HouseHoldMemberRepository(EMRDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HouseHoldMember>> GetHouseHoldMembersWithDetails(string houseHoldNo)
        {
            var houseHoldMembers = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Include(m => m.HouseHold)
                .Where(m => m.HouseHoldNo.Equals(houseHoldNo))
                .ToListAsync();

            return houseHoldMembers;
        }

        public async Task<HouseHoldMember> GetHouseHoldMemberWithDetails(int id)
        {
            var houseHoldMember = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Include(m => m.HouseHold)
                .FirstOrDefaultAsync(m => m.Id == id);

            return houseHoldMember;
        }
    }
}
