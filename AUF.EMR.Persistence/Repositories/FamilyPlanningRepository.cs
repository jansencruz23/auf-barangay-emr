using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.Common;
using AUF.EMR.Domain.Models.FamilyPlanning;
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

        public async Task<FamilyPlanningRecord> AddFamilyPlanning(FamilyPlanningRecord fpRecord)
        {
            var clientType = fpRecord.ClientType;
            var medicalHistory = fpRecord.MedicalHistory;
            var obstetricalHistory = fpRecord.ObstetricalHistory;
            var risksForSTI = fpRecord.RisksForSTI;
            var risksForVAR = fpRecord.RisksForVAW;
            var physicalExam = fpRecord.PhysicalExamination;

            await _dbContext.Set<ClientType>().AddAsync(clientType);
            await _dbContext.Set<MedicalHistory>().AddAsync(medicalHistory);
            await _dbContext.Set<ObstetricalHistory>().AddAsync(obstetricalHistory);
            await _dbContext.Set<RisksForSTI>().AddAsync(risksForSTI);
            await _dbContext.Set<RisksForVAW>().AddAsync(risksForVAR);
            await _dbContext.Set<PhysicalExamination>().AddAsync(physicalExam);
            await _dbContext.Set<FamilyPlanningRecord>().AddAsync(fpRecord);

            await _dbContext.SaveChangesAsync();
            return fpRecord;
        }

        public async Task<List<FamilyPlanningRecord>> GetFPRecordsWithDetails(string householdNo)
        {
            var records = await _dbContext.FamilyPlanningRecords
                .AsNoTracking()
                .Include(f => f.ClientHouseholdMember)
                    .ThenInclude(m => m.Household)
                .Include(f => f.ClientType)
                .Include(f => f.MedicalHistory)
                .Include(f => f.ObstetricalHistory)
                .Include(f => f.PhysicalExamination)
                .Include(f => f.RisksForSTI)
                .Include(f => f.RisksForVAW)
                .Where(f => f.Status && 
                    f.ClientHouseholdMember.Status &&
                    f.ClientHouseholdMember.Household.HouseholdNo.Equals(householdNo))
                .ToListAsync();

            return records;
        }

        public async Task<FamilyPlanningRecord> GetFPRecordWithDetails(int id)
        {
            var record = await _dbContext.FamilyPlanningRecords
                .AsNoTracking()
                .Include(f => f.ClientHouseholdMember)
                    .ThenInclude(m => m.Household)
                .Include(f => f.ClientType)
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
