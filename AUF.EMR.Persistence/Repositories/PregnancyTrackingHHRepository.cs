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
    public class PregnancyTrackingHHRepository : GenericRepository<PregnancyTrackingHH>, IPregnancyTrackingHHRepository
    {
        private readonly EMRDbContext _dbContext;

        public PregnancyTrackingHHRepository(EMRDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PregnancyTrackingHH> GetPregnancyTrackingHHWithDetails(int id)
        {
            var entity = await _dbContext.PregnancyTrackingHHs
                .AsNoTracking()
                .Include(p => p.Household)
                .FirstOrDefaultAsync(p => p.Household.Id == id);

            return entity;
        }

        public async Task<PregnancyTrackingHH> GetPregnancyTrackingHHWithDetails(string householdNo)
        {
            var entity = await _dbContext.PregnancyTrackingHHs
                .AsNoTracking()
                .Include(p => p.Household)
                .FirstOrDefaultAsync(p => p.Household.HouseholdNo.Equals(householdNo));

            return entity;
        }
    }
}
