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
    public class MasterlistRepository : GenericRepository<HouseholdMember>, IMasterlistRepository
    {
        private readonly EMRDbContext _dbContext;

        public MasterlistRepository(EMRDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HouseholdMember>> GetMasterlistQuery(string householdNo, DateTime startDate)
        {
            var newborns = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status)
                .Where(m => m.HouseholdNo.Equals(householdNo) && m.Status)
                .Where(m => m.Birthday >= startDate && m.Birthday <= DateTime.Today)
                .ToListAsync();

            return newborns;
        }

        public async Task<List<HouseholdMember>> GetAllMasterlist(string householdNo)
        {
            var masterlist = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status)
                .Where(m => m.HouseholdNo.Equals(householdNo) && m.Status)
                .ToListAsync();

            return masterlist;
        }

        public async Task<List<HouseholdMember>> GetMasterlistQuery(string householdNo, 
            DateTime startDate, DateTime endDate)
        {
            var newborns = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status)
                .Where(m => m.HouseholdNo.Equals(householdNo) && m.Status)
                .Where(m => m.Birthday >= startDate && m.Birthday <= endDate)
                .ToListAsync();

            return newborns;
        }
    }
}
