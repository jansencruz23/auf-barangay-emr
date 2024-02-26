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
    public class HouseholdRepository : GenericRepository<Household>, IHouseholdRepository
    {
        private readonly EMRDbContext _dbContext;

        public HouseholdRepository(EMRDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetHouseholdId(string houseHoldNo)
        {
            var houseHold = await _dbContext.HouseHolds
                .FirstOrDefaultAsync(h => h.HouseholdNo.Equals(houseHoldNo));

            return houseHold.Id;
        }

        public async Task<List<Household>> GetHouseholdsWithDetails()
        {
            var houseHolds = await _dbContext.HouseHolds
                .AsNoTracking()
                .Include(h => h.HouseholdMembers)
                .ToListAsync();

            return houseHolds;
        }

        public async Task<Household> GetHouseholdWithDetails(int id)
        {
            var houseHold = await _dbContext.HouseHolds
                .AsNoTracking()
                .Include(h => h.HouseholdMembers)
                .FirstOrDefaultAsync(h => h.Id == id);

            return houseHold;
        }

        public async Task<List<Household>> GetSearchedHouseholdsWithDetails(string query)
        {
            var houseHolds = await _dbContext.HouseHolds
                .AsNoTracking()
                .Include(h => h.HouseholdMembers)
                .Where(h =>
                    h.LastName.Contains(query) ||
                    h.FirstName.Contains(query) ||
                    h.HouseholdNo.Contains(query) ||
                    h.HouseholdMembers.Any(m =>
                        m.LastName.Contains(query) ||
                        m.FirstName.Contains(query)))
                .ToListAsync();

            return houseHolds;
        }

        public async Task<List<Household>> GetSearchedHouseholdWithDetails(string query)
        {
            var household = await _dbContext.HouseHolds
                .AsNoTracking()
                .Include(h => h.HouseholdMembers)
                .Where(h => h.HouseholdNo.Equals(query))
                .ToListAsync();

            return household;
        }
    }
}
