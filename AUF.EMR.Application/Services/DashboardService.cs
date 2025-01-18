using AUF.EMR.Application.Constants;
using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _repository;

        public DashboardService(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> GetAdolescentCount()
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.AdolescentStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.AdolescentEnd);

            return await _repository.GetMemberByAgeCount(startDate, endDate);
        }

        public async Task<int> GetAdolescentCount(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.AdolescentStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.AdolescentEnd);

            return await _repository.GetMemberByAgeCount(householdNo, startDate, endDate);
        }

        public async Task<int> GetAdultsCount()
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultEnd);

            return await _repository.GetMemberByAgeCount(startDate, endDate);
        }

        public async Task<int> GetAdultsCount(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultEnd);

            return await _repository.GetMemberByAgeCount(householdNo, startDate, endDate);
        }

        public async Task<int> GetDiabetesRiskRecordCount(string householdNo)
        {
            return await _repository.GetDiabetesRiskRecordCount(householdNo);
        }

        public async Task<int> GetDiabetesRiskRecordCount()
        {
            return await _repository.GetDiabetesRiskRecordCount();
        }

        public async Task<int> GetFamilyPlanningFormCount()
        {
            return await _repository.GetFamilyPlanningFormCount();
        }

        public async Task<int> GetFamilyPlanningFormCount(string householdNo)
        {
            return await _repository.GetFamilyPlanningFormCount(householdNo);
        }

        public async Task<int> GetHouseholdCount()
        {
            return await _repository.GetHouseholdCount();
        }

        public async Task<int> GetHouseholdCount(int days)
        {
            return await _repository.GetHouseholdCount(days);
        }

        public async Task<int> GetHouseholdCount(int days, int daysDeleted)
        {
            return await _repository.GetHouseholdCount(days, daysDeleted);
        }

        public async Task<int> GetHouseholdMemberCount()
        {
            return await _repository.GetHouseholdMemberCount();
        }

        public async Task<int> GetHouseholdMemberCount(string householdNo)
        {
            return await _repository.GetHouseholdMemberCount(householdNo);
        }

        public async Task<int> GetInfantCount()
        {
            var startDate = DateTime.Today.AddMonths(MasterlistAgeRange.InfantStart).AddDays(1);
            var endDate = DateTime.Today.AddDays(MasterlistAgeRange.InfantEnd);

            return await _repository.GetMemberByAgeCount(startDate, endDate);
        }

        public async Task<int> GetInfantCount(string householdNo)
        {
            var startDate = DateTime.Today.AddMonths(MasterlistAgeRange.InfantStart).AddDays(1);
            var endDate = DateTime.Today.AddDays(MasterlistAgeRange.InfantEnd);

            return await _repository.GetMemberByAgeCount(householdNo, startDate, endDate);
        }

        public async Task<int> GetNewbornCount()
        {
            var startDate = DateTime.Today.AddDays(MasterlistAgeRange.NewbornStart);
            var endDate = DateTime.Today;

            return await _repository.GetMemberByAgeCount(startDate, endDate);
        }

        public async Task<int> GetNewbornCount(string householdNo)
        {
            var startDate = DateTime.Today.AddDays(MasterlistAgeRange.NewbornStart);
            var endDate = DateTime.Today;

            return await _repository.GetMemberByAgeCount(householdNo, startDate, endDate);
        }

        public async Task<int> GetPatientRecordCount()
        {
            return await _repository.GetPatientRecordCount();
        }

        public async Task<int> GetPatientRecordCount(string householdNo)
        {
            return await _repository.GetPatientRecordCount(householdNo);
        }

        public async Task<int> GetPregnancyRecordCount()
        {
            return await _repository.GetPregnancyRecordCount();
        }

        public async Task<int> GetPregnancyRecordCount(string householdNo)
        {
            return await _repository.GetPregnancyRecordCount(householdNo);
        }

        public async Task<int> GetPregnancyTrackingFormCount()
        {
            return await _repository.GetPregnancyTrackingFormCount();
        }

        public async Task<int> GetPregnancyTrackingFormCount(string householdNo)
        {
            return await _repository.GetPregnancyTrackingFormCount(householdNo);
        }

        public async Task<int> GetPregnantCount()
        {
            return await _repository.GetPregnantCount();
        }

        public async Task<int> GetPregnantCount(string householdNo)
        {
            return await _repository.GetPregnantCount(householdNo);
        }

        public async Task<int> GetSchoolAgedCount()
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.SchoolAgedStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.SchoolAgedEnd);

            return await _repository.GetMemberByAgeCount(startDate, endDate);
        }

        public async Task<int> GetSchoolAgedCount(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.SchoolAgedStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.SchoolAgedEnd);

            return await _repository.GetMemberByAgeCount(householdNo, startDate, endDate);
        }

        public async Task<int> GetSeniorCount()
        {
            var startDate = DateTime.MinValue;
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.SeniorEnd);

            return await _repository.GetMemberByAgeCount(startDate, endDate);
        }

        public async Task<int> GetSeniorCount(string householdNo)
        {
            var startDate = DateTime.MinValue;
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.SeniorEnd);

            return await _repository.GetMemberByAgeCount(householdNo, startDate, endDate);
        }

        public async Task<int> GetUnderFiveCount()
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveEnd);

            return await _repository.GetMemberByAgeCount(startDate, endDate);
        }

        public async Task<int> GetUnderFiveCount(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveEnd);

            return await _repository.GetMemberByAgeCount(householdNo, startDate, endDate);
        }

        public async Task<int> GetWRAFormCount()
        {
            return await _repository.GetWRAFormCount();
        }

        public async Task<int> GetWRAFormCount(string householdNo)
        {
            return await _repository.GetWRAFormCount(householdNo);
        }
    }
}
