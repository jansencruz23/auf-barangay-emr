using AUF.EMR.Application.Common;
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

            var wraForms = await _dbContext.WomanOfReproductiveAges
                .Include(w => w.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(w => w.HouseholdMember.Household.HouseholdNo.Equals(household.HouseholdNo))
                .ToListAsync();

            var pregForms = await _dbContext.PregnancyTrackings
                .Include(p => p.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(p => p.HouseholdMember.Household.HouseholdNo.Equals(household.HouseholdNo))
                .ToListAsync();

            var pregHHForm = await _dbContext.PregnancyTrackingHHs
                .FirstOrDefaultAsync(p => p.HouseholdId == id);

            var fpForms = await _dbContext.FamilyPlanningRecords
                .Include(f => f.ClientHouseholdMember)
                    .ThenInclude(c => c.Household)
                .Where(p => p.ClientHouseholdMember.Household.HouseholdNo.Equals(household.HouseholdNo))
                .ToListAsync();

            var patientForms = await _dbContext.PatientRecords
                .Include(p => p.Patient)
                    .ThenInclude(a => a.Household)
                .Where(p => p.Patient.Household.HouseholdNo.Equals(household.HouseholdNo))
                .ToListAsync();

            var vaccineAppointments = await _dbContext.VaccinationAppointments
                .Include(v => v.PatientRecord)
                    .ThenInclude(p => p.Patient)
                        .ThenInclude(s => s.Household)
                .Where(p => p.PatientRecord.Patient.Household.HouseholdNo.Equals(household.HouseholdNo))
                .ToListAsync();

            var pregRecordForms = await _dbContext.PregnancyRecords
                .Include(p => p.Patient)
                    .ThenInclude(a => a.Household)
                .Where(p => p.Patient.Household.HouseholdNo.Equals(household.HouseholdNo))
                .ToListAsync();

            var pregAppointments = await _dbContext.PregnancyAppointments
                .Include(p => p.PregnancyRecord)
                    .ThenInclude(r => r.Patient)
                        .ThenInclude(p => p.Household)
                .Where(p => p.PregnancyRecord.Patient.Household.HouseholdNo.Equals(household.HouseholdNo))
                .ToListAsync();

            if (household != null)
            {
                foreach (var member in household.HouseholdMembers)
                {
                    member.Status = false;
                }

                foreach (var wra in wraForms)
                {
                    wra.Status = false;
                }

                foreach (var preg in pregForms)
                {
                    preg.Status = false;
                }

                foreach (var fp in fpForms)
                {
                    fp.Status = false;
                }

                foreach (var form in patientForms)
                {
                    form.Status = false;
                }

                foreach (var form in vaccineAppointments)
                {
                    form.Status = false;
                }

                foreach (var form in pregRecordForms)
                {
                    form.Status = false;
                }

                foreach (var form in pregAppointments)
                {
                    form.Status = false;
                }

                if (pregHHForm != null)
                {
                    pregHHForm.Status = false;
                }

                household.Status = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<int> GetHouseholdId(string householdNo)
        {
            var household = await _dbContext.Households
                .AsNoTracking()
                .Where(h => h.Status)
                .FirstOrDefaultAsync(h => h.HouseholdNo.Equals(householdNo));

            return household.Id;
        }

        public async Task<string> GetHouseholdNo(int id)
        {
            var household = await _dbContext.Households
                .AsNoTracking()
                .Where(h => h.Status)
                .FirstOrDefaultAsync(h => h.Id == id);

            return household.HouseholdNo;
        }

        public async Task<PaginatedList<Household>> GetHouseholdsWithDetails(int page)
        {
            var households = _dbContext.Households
                .AsNoTracking()
                .Include(h => h.HouseholdMembers.Where(m => m.Status))
                .Where(h => h.Status)
                .OrderByDescending(p => p.LastModified);

            var pagedHouseholds = await PaginatedList<Household>.CreateAsync(households, page);

            foreach (var household in households)
            {
                household.HouseholdMembers = household.HouseholdMembers
                    .OrderBy(m => m.RelationshipToHouseholdHead == 1 ? 0 : m.RelationshipToHouseholdHead)
                        .ThenBy(m => m.RelationshipToHouseholdHead == 2 ? 1 : m.RelationshipToHouseholdHead)
                        .ThenBy(m => m.RelationshipToHouseholdHead == 3 || m.RelationshipToHouseholdHead == 4 ? m.Birthday : DateTime.MaxValue)
                    .ToList();
            }

            return pagedHouseholds;
        }

        public async Task<Household> GetHouseholdWithDetails(int id)
        {
            var household = await _dbContext.Households
                .AsNoTracking()
                .Include(h => h.HouseholdMembers.Where(m => m.Status))
                .Where(h => h.Status)
                .FirstOrDefaultAsync(h => h.Id == id);

            return household;
        }

        public async Task<Household> GetHouseholdWithDetails(string householdNo)
        {
            var household = await _dbContext.Households
                .AsNoTracking()
                .Include(h => h.HouseholdMembers.Where(m => m.Status))
                .Where(h => h.Status)
                .FirstOrDefaultAsync(h => h.HouseholdNo.Equals(householdNo));

            return household;
        }

        public async Task<PaginatedList<Household>> GetSearchedHouseholdsWithDetails(string query, int page)
        {
            var households = _dbContext.Households
                .AsNoTracking()
                .Include(h => h.HouseholdMembers.Where(m => m.Status))
                .Where(h => h.Status)
                .Where(h => h.LastName.Contains(query) ||
                    h.FirstName.Contains(query) ||
                    h.HouseholdNo.Contains(query) ||
                    h.HouseholdMembers.Any(m =>
                        m.LastName.Contains(query) ||
                        m.FirstName.Contains(query) && m.Status));

            var pagedHouseholds = await PaginatedList<Household>.CreateAsync(households, page);

            return pagedHouseholds;
        }

        public async Task<Household> GetSearchedHouseholdWithDetails(string householdNo)
        {
            var household = await _dbContext.Households
                .AsNoTracking()
                .Include(h => h.HouseholdMembers.Where(m => m.Status))
                .FirstOrDefaultAsync(h => h.HouseholdNo.Equals(householdNo) && h.Status);

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
