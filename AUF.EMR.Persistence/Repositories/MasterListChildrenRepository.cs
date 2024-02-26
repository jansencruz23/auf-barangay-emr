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
    public class MasterListChildrenRepository : GenericRepository<MasterListChildren>, IMasterListChildrenRepository
    {
        private readonly EMRDbContext _dbContext;

        public MasterListChildrenRepository(EMRDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MasterListChildren>> GetMasterListChildrenWithDetails(string householdNo)
        {
            var masterList = await _dbContext.MasterListChildren
                .AsNoTracking()
                .Include(m => m.HouseholdMember)
                    .ThenInclude(h => h.Household)
                .Where(m => m.HouseholdMember.HouseholdNo.Equals(householdNo))
                .ToListAsync();

            return masterList;
        }

        public async Task<MasterListChildren> GetMasterListChildWithDetails(int id)
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
