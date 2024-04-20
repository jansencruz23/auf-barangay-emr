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

        public async Task DeleteHousehold(int id)
        {
            var household = await _dbContext.Households
                .Include(h => h.HouseholdMembers)
                .FirstOrDefaultAsync(h => h.Id == id);

            var wras = await _dbContext.WomanOfReproductiveAges
                .Where(w => w.HouseholdNo.Equals(household.HouseholdNo))
                .ToListAsync();

            var pregTrack = await _dbContext.PregnancyTrackings
                .Where(p => p.HouseholdNo.Equals(household.HouseholdNo))
                .ToListAsync();

            if (household != null)
            {
                foreach (var member in household.HouseholdMembers)
                {
                    member.Status = false;
                }

                foreach (var wra in wras)
                {
                    wra.Status = false;
                }

                foreach (var preg in pregTrack)
                {
                    preg.Status = false;
                }

                household.Status = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<int> GetHouseholdId(string houseHoldNo)
        {
            var houseHold = await _dbContext.Households
                .AsNoTracking()
                .Where(h => h.Status)
                .FirstOrDefaultAsync(h => h.HouseholdNo.Equals(houseHoldNo));

            return houseHold.Id;
        }

        public async Task<List<Household>> GetHouseholdsWithDetails()
        {
            var houseHolds = await _dbContext.Households
                .AsNoTracking()
                .Include(h => h.HouseholdMembers)
                .Where(h => h.Status)
                .ToListAsync();

            return houseHolds;
        }

        public async Task<Household> GetHouseholdWithDetails(int id)
        {
            var houseHold = await _dbContext.Households
                .AsNoTracking()
                .Include(h => h.HouseholdMembers)
                .Where(h => h.Status)
                .FirstOrDefaultAsync(h => h.Id == id);

            return houseHold;
        }

        public async Task<List<Household>> GetSearchedHouseholdsWithDetails(string query)
        {
            var houseHolds = await _dbContext.Households
                .AsNoTracking()
                .Include(h => h.HouseholdMembers)
                .Where(h => h.Status)
                .Where(h => h.LastName.Contains(query) ||
                    h.FirstName.Contains(query) ||
                    h.HouseholdNo.Contains(query) ||
                    h.HouseholdMembers.Any(m =>
                        m.LastName.Contains(query) ||
                        m.FirstName.Contains(query) && m.Status))
                .ToListAsync();

            return houseHolds;
        }

        public async Task<List<Household>> GetSearchedHouseholdWithDetails(string query)
        {
            var household = await _dbContext.Households
                .AsNoTracking()
                .Include(h => h.HouseholdMembers)
                .Where(h => h.HouseholdNo.Equals(query) && h.Status)
                .ToListAsync();

            return household;
        }

        public async Task<bool> IsHouseholdNoExisting(string householdNo)
        {
            var household = await _dbContext.Households
                .AsNoTracking()
                .Where(h => h.Status)
                .FirstOrDefaultAsync(h => h.HouseholdNo.Equals(householdNo));

            return household != null;
        }
    }
}
