using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Domain.Models;
using AUF.EMR.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence.Repositories
{
    public class WRARepository : GenericRepository<WomanOfReproductiveAge>, IWRARepository
    {
        private readonly EMRDbContext _dbContext;

        public WRARepository(EMRDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<WomanOfReproductiveAge>> GetWRAListWithDetails(string householdNo)
        {
            var wraList = await _dbContext.WomanOfReproductiveAges
                .AsNoTracking()
                .Include(w => w.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(w => w.HouseholdMember.Household.HouseholdNo.Equals(householdNo) && w.Status)
                .ToListAsync();

            return wraList;
        }

        public async Task<WomanOfReproductiveAge> GetWRAWithDetails(int id)
        {
            var wra = await _dbContext.WomanOfReproductiveAges
                .AsNoTracking()
                .Include(w => w.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(w => w.Status)
                .FirstOrDefaultAsync(w => w.Id == id);

            return wra;
        }
    }
}
