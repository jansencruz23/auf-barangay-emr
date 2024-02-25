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
    public class HouseHoldRepository : GenericRepository<HouseHold>, IHouseHoldRepository
    {
        private readonly EMRDbContext _dbContext;

        public HouseHoldRepository(EMRDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HouseHold>> GetHouseHoldsWithDetails()
        {
            var houseHolds = await _dbContext.HouseHolds
                .AsNoTracking()
                .Include(h => h.HouseHoldMembers)
                .ToListAsync();

            return houseHolds;
        }

        public async Task<HouseHold> GetHouseHoldWithDetails(int id)
        {
            var houseHold = await _dbContext.HouseHolds
                .AsNoTracking()
                .Include(h => h.HouseHoldMembers)
                .FirstOrDefaultAsync(h => h.Id == id);

            return houseHold;
        }
    }
}
