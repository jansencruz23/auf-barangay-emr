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
    public class FamilyPlanningRepository : GenericRepository<FamilyPlanningRecord>, IFamilyPlanningRepository
    {
        private readonly EMRDbContext _dbContext;

        public FamilyPlanningRepository(EMRDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FamilyPlanningRecord>> GetFPRecordsWithDetails(string householdNo)
        {
            var records = await _dbContext.FamilyPlanningRecords
                .AsNoTracking()
                .Include(f => f.ClientHouseholdMember)
                    .ThenInclude(m => m.Household)
                .Include(f => f.SpouseHouseholdMember)
                .Include(f => f.ClientAge)
                .Include(f => f.MedicalHistory)
                .Include(f => f.ObstetricalHistory)
                .Include(f => f.PhysicalExamination)
                .Include(f => f.RisksForSTI)
                .Include(f => f.RisksForVAW)
                .Where(f => f.Status
                    && f.ClientHouseholdMember.Household.HouseholdNo.Equals(householdNo))
                .ToListAsync();

            return records;
        }

        public async Task<FamilyPlanningRecord> GetFPRecordWithDetails(int id)
        {
            var record = await _dbContext.FamilyPlanningRecords
                .AsNoTracking()
                .Include(f => f.ClientHouseholdMember)
                    .ThenInclude(m => m.Household)
                .Include(f => f.SpouseHouseholdMember)
                .Include(f => f.ClientAge)
                .Include(f => f.MedicalHistory)
                .Include(f => f.ObstetricalHistory)
                .Include(f => f.PhysicalExamination)
                .Include(f => f.RisksForSTI)
                .Include(f => f.RisksForVAW)
                .FirstOrDefaultAsync(f => f.Status && f.Id == id);

            return record;
        }
    }
}
