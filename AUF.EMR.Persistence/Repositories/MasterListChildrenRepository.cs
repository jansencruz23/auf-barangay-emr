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
    public class MasterlistChildrenRepository : GenericRepository<MasterlistChildren>, IMasterlistChildrenRepository
    {
        private readonly EMRDbContext _dbContext;

        public MasterlistChildrenRepository(EMRDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MasterlistChildren>> GetMasterlistChildrenWithDetails(string householdNo)
        {
            var masterList = await _dbContext.MasterListChildren
                .AsNoTracking()
                .Include(m => m.HouseholdMember)
                    .ThenInclude(h => h.Household)
                .Where(m => m.HouseholdMember.HouseholdNo.Equals(householdNo))
                .ToListAsync();

            return masterList;
        }

        public async Task<MasterlistChildren> GetMasterlistChildWithDetails(int id)
        {
            var child = await _dbContext.MasterListChildren
                .AsNoTracking()
                .Include(c => c.HouseholdMember)
                    .ThenInclude(h => h.Household)
                .FirstOrDefaultAsync(c => c.Id == id);

            return child;
        }
    }
}
