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

        public Task<List<HouseholdMember>> GetMasterlistQuery(string householdNo, DateTime startDate)
        {
            var newborns = _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.HouseholdNo.Equals(householdNo))
                .Where(m => m.Birthday >= startDate && m.Birthday <= DateTime.Today)
                .ToListAsync();

            return newborns;
        }

        public Task<List<HouseholdMember>> GetAllMasterlist(string householdNo)
        {
            throw new NotImplementedException();
        }
    }
}
