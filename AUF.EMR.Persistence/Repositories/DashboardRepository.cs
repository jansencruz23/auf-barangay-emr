using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly EMRDbContext _dbContext;

        public DashboardRepository(EMRDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetFamilyPlanningFormCount()
        {
            var count = await _dbContext.FamilyPlanningRecords
                .AsNoTracking()
                .Include(f => f.ClientHouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(f => f.Status &&
                    f.ClientHouseholdMember.Household.Status &&
                    f.ClientHouseholdMember.Status)
                .CountAsync();

            return count;
        }

        public async Task<int> GetFamilyPlanningFormCount(string householdNo)
        {
            var count = await _dbContext.FamilyPlanningRecords
                .AsNoTracking()
                .Include(f => f.ClientHouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(f => f.Status &&
                    f.ClientHouseholdMember.Household.Status &&
                    f.ClientHouseholdMember.Status &&
                    f.ClientHouseholdMember.Household.HouseholdNo.Equals(householdNo))
                .CountAsync();

            return count;
        }

        public async Task<int> GetHouseholdCount()
        {
            var count = await _dbContext.Households
                .AsNoTracking()
                .Where(h => h.Status)
                .CountAsync();

            return count;
        }

        public async Task<int> GetHouseholdCount(int days)
        {
            var dateThreshold = DateTime.UtcNow.Date.AddDays(-days);
            var count = await _dbContext.Households
                .AsNoTracking()
                .Where(h => h.Status && h.DateCreated <= dateThreshold)
                .CountAsync();

            return count;
        }

        public async Task<int> GetHouseholdMemberCount()
        {
            var count = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Where(h => h.Status)
                .CountAsync();

            return count;
        }

        public async Task<int> GetHouseholdMemberCount(string householdNo)
        {
            var count = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Status &&
                    m.Household.HouseholdNo.Equals(householdNo))
                .CountAsync();

            return count;
        }

        public async Task<int> GetMemberByAgeCount(DateTime startDate, DateTime endDate)
        {
            var count = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Where(m => m.Status &&
                    m.Birthday >= startDate &&
                    m.Birthday <= endDate)
                .CountAsync();

            return count;
        }

        public async Task<int> GetMemberByAgeCount(string householdNo, DateTime startDate, DateTime endDate)
        {
            var count = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Status &&
                    m.Household.HouseholdNo.Equals(householdNo) &&
                    m.Birthday >= startDate &&
                    m.Birthday <= endDate)
                .CountAsync();

            return count;
        }

        public async Task<int> GetPatientRecordCount()
        {
            var count = await _dbContext.PatientRecords
                .AsNoTracking()
                .Include(p => p.VaccinationAppointments)
                    .ThenInclude(v => v.VaccinationRecords)
                        .ThenInclude(r => r.Vaccine)
                .Include(p => p.Patient)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status &&
                    p.Patient.Status &&
                    p.Patient.Household.Status)
                .CountAsync();

            return count;
        }

        public async Task<int> GetPatientRecordCount(string householdNo)
        {
            var count = await _dbContext.PatientRecords
                .AsNoTracking()
                .Include(p => p.VaccinationAppointments)
                    .ThenInclude(v => v.VaccinationRecords)
                        .ThenInclude(r => r.Vaccine)
                .Include(p => p.Patient)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status &&
                    p.Patient.Status &&
                    p.Patient.Household.Status &&
                    p.Patient.Household.HouseholdNo.Equals(householdNo))
                .CountAsync();

            return count;
        }

        public async Task<int> GetPregnancyRecordCount()
        {
            var records = await _dbContext.PregnancyRecords
                .AsNoTracking()
                .Include(r => r.Patient)
                    .ThenInclude(p => p.Household)
                .Include(r => r.PregnancyAppointments.Where(a => a.Status))
                .Where(r => r.Status &&
                    r.Patient.Status &&
                    r.Patient.Household.Status)
                .CountAsync();

            return records;
        }

        public async Task<int> GetPregnancyRecordCount(string householdNo)
        {
            var count = await _dbContext.PregnancyTrackings
                .AsNoTracking()
                .Include(p => p.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status &&
                    p.HouseholdMember.Household.Status &&
                    p.HouseholdMember.Status &&
                    p.HouseholdMember.Household.HouseholdNo.Equals(householdNo))
                .CountAsync();

            return count;
        }

        public async Task<int> GetPregnancyTrackingFormCount()
        {
            var count = await _dbContext.PregnancyTrackings
                .AsNoTracking()
                .Include(p => p.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status &&
                    p.HouseholdMember.Household.Status &&
                    p.HouseholdMember.Status)
                .CountAsync();

            return count;
        }

        public async Task<int> GetPregnancyTrackingFormCount(string householdNo)
        {
            var count = await _dbContext.PregnancyTrackings
                .AsNoTracking()
                .Include(p => p.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status &&
                    p.HouseholdMember.Household.HouseholdNo.Equals(householdNo) &&
                    p.HouseholdMember.Household.Status &&
                    p.HouseholdMember.Status)
                .CountAsync();

            return count;
        }

        public async Task<int> GetPregnantCount()
        {
            var count = await _dbContext.PregnancyTrackings
                .AsNoTracking()
                .Include(p => p.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status &&
                    p.HouseholdMember.Household.Status &&
                    p.HouseholdMember.Status)
                .Where(p => p.PregnancyOutcome == null)
                .Select(p => p.HouseholdMember)
                .Distinct()
                .CountAsync();

            return count;
        }

        public async Task<int> GetPregnantCount(string householdNo)
        {
            var count = await _dbContext.PregnancyTrackings
                .AsNoTracking()
                .Include(p => p.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status &&
                    p.HouseholdMember.Household.HouseholdNo.Equals(householdNo) &&
                    p.HouseholdMember.Household.Status &&
                    p.HouseholdMember.Status)
                .Where(p => p.PregnancyOutcome == null)
                .Select(p => p.HouseholdMember)
                .Distinct()
                .CountAsync();

            return count;
        }

        public async Task<int> GetWRAFormCount()
        {
            var count = await _dbContext.WomanOfReproductiveAges
                .AsNoTracking()
                    .Include(w => w.HouseholdMember)
                        .ThenInclude(m => m.Household)
                .Where(w => w.Status &&
                    w.HouseholdMember.Status &&
                    w.HouseholdMember.Household.Status)
                .CountAsync();

            return count;
        }

        public async Task<int> GetWRAFormCount(string householdNo)
        {
            var count = await _dbContext.WomanOfReproductiveAges
                .AsNoTracking()
                .Include(w => w.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(w => w.HouseholdMember.Household.HouseholdNo.Equals(householdNo) &&
                    w.Status &&
                    w.HouseholdMember.Status &&
                    w.HouseholdMember.Household.Status)
                .CountAsync();

            return count;
        }
    }
}
