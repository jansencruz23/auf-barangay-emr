using AUF.EMR.Application.Constants;
using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly ISummaryRepository _dashboardRepository;
        private readonly IRecordRepository _recordRepository;

        public SummaryService(ISummaryRepository dashboardRepository,
            IRecordRepository recordRepository)
        {
            _dashboardRepository = dashboardRepository;
            _recordRepository = recordRepository;
        }

        public async Task<IReadOnlyList<RecordLog>> GetAllCheckedToday(Guid id)
        {
            return await _recordRepository.GetRecordsToday(id);
        }

        public async Task<int> GetCheckedAdolescentToday(Guid id)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.AdolescentStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.AdolescentEnd);

            return await _dashboardRepository.GetCheckedPatientsToday(id, startDate, endDate);
        }

        public async Task<int> GetCheckedAdultToday(Guid id)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultEnd);

            return await _dashboardRepository.GetCheckedPatientsToday(id, startDate, endDate);
        }

        public async Task<int> GetCheckedInfantToday(Guid id)
        {
            var startDate = DateTime.Today.AddMonths(MasterlistAgeRange.InfantStart).AddDays(1);
            var endDate = DateTime.Today.AddDays(MasterlistAgeRange.InfantEnd);

            return await _dashboardRepository.GetCheckedPatientsToday(id, startDate, endDate);
        }

        public async Task<int> GetCheckedNewbornToday(Guid id)
        {
            var startDate = DateTime.Today.AddDays(MasterlistAgeRange.NewbornStart);
            var endDate = DateTime.Today;

            return await _dashboardRepository.GetCheckedPatientsToday(id, startDate, endDate);
        }

        public async Task<int> GetCheckedSchoolAgedToday(Guid id)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.SchoolAgedStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.SchoolAgedEnd);

            return await _dashboardRepository.GetCheckedPatientsToday(id, startDate, endDate);
        }

        public async Task<int> GetCheckedSeniorToday(Guid id)
        {
            var startDate = DateTime.MinValue;
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.SeniorEnd);

            return await _dashboardRepository.GetCheckedPatientsToday(id, startDate, endDate);
        }

        public async Task<int> GetCheckedUnderFiveToday(Guid id)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveEnd);

            return await _dashboardRepository.GetCheckedPatientsToday(id, startDate, endDate);
        }
    }
}
