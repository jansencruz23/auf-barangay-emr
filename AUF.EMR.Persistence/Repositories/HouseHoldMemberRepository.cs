using AUF.EMR.Application.Constants;
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
    public class HouseholdMemberRepository : GenericRepository<HouseholdMember>, IHouseholdMemberRepository
    {
        private readonly EMRDbContext _dbContext;

        public HouseholdMemberRepository(EMRDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteHouseholdMember(int id)
        {
            var member = await _dbContext.HouseholdMembers
                .FindAsync(id);

            var wraForms = await _dbContext.WomanOfReproductiveAges
                .Where(w => w.HouseholdMemberId == id)
                .ToListAsync();

            var pregForms = await _dbContext.PregnancyTrackings
                .Where(p => p.HouseholdMemberId == id)
                .ToListAsync();

            var familyPlanning = await _dbContext.FamilyPlanningRecords
                .Where(p => p.ClientHouseholdMemberId == id)
                .ToListAsync();

            var patientRecord = await _dbContext.PatientRecords
                .Where(p => p.PatientId == id)
                .ToListAsync();

            var pregRecord = await _dbContext.PregnancyRecords
                .Where(p => p.PatientId == id)
                .ToListAsync();

            if (member != null)
            {
                foreach (var wra in wraForms)
                {
                    wra.Status = false;
                }

                foreach (var preg in pregForms)
                {
                    preg.Status = false;
                }

                foreach (var form in familyPlanning)
                {
                    form.Status = false;
                }

                foreach (var form in patientRecord)
                {
                    form.Status = false;
                }

                foreach (var form in pregRecord)
                {
                    form.Status = false;
                }

                member.Status = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<HouseholdMember>> GetHouseholdMembersWithDetails(string houseHoldNo)
        {
            var houseHoldMembers = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status && m.Household.HouseholdNo.Equals(houseHoldNo) && m.Status)
                .OrderBy(m => m.RelationshipToHouseholdHead == 1 ? 0 :
                              m.RelationshipToHouseholdHead == 2 ? 1 :
                              m.RelationshipToHouseholdHead == 3 || m.RelationshipToHouseholdHead == 4 ? 2 : 3)
                .ThenBy(m => m.RelationshipToHouseholdHead == 3 || m.RelationshipToHouseholdHead == 4 ? m.Birthday : DateTime.MaxValue)
                .ToListAsync();

            return houseHoldMembers;
        }

        public async Task<List<HouseholdMember>> GetHouseholdMembersWithDetails(Guid id, DateTime startDate, DateTime endDate)
        {
            var householdMembers = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.ModifiedById == id &&
                            m.Household.Status &&
                            m.Status &&
                            m.LastModified >= startDate &&
                            m.LastModified <= endDate)
                .ToListAsync();

            return householdMembers;
        }

        public async Task<HouseholdMember> GetHouseholdMemberWithDetails(int id)
        {
            var houseHoldMember = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status && m.Status)
                .FirstOrDefaultAsync(m => m.Id == id);

            return houseHoldMember;
        }

        public async Task<List<HouseholdMember>> GetWRAHouseholdMembers(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(WRAAgeRange.WRAStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(WRAAgeRange.WRAEnd);

            var WraMembers = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Status && m.Household.Status &&
                            m.Household.HouseholdNo.Equals(householdNo) &&
                            m.Sex.Equals('F') &&
                            m.Birthday >= startDate &&
                            m.Birthday <= endDate)
                .ToListAsync();

            return WraMembers;
        }
    }
}
