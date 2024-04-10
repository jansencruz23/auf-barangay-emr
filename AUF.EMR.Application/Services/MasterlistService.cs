using AUF.EMR.Application.Constants;
using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Services
{
    public class MasterlistService : GenericService<HouseholdMember>, IMasterlistService
    {
        private readonly IMasterlistRepository _repository;

        public MasterlistService(IMasterlistRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Task<List<HouseholdMember>> GetAllMasterlist(string householdNo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HouseholdMember>> GetMasterlistNewborn(string householdNo)
        {
            var startDate = DateTime.Today.AddDays(MasterlistAgeRange.NewbornStart);
            return await _repository.GetListQuery(householdNo, startDate);
        }

        public async Task<List<HouseholdMember>> GetMasterlistInfant(string householdNo)
        {
            var startDate = DateTime.Today.AddMonths(MasterlistAgeRange.InfantStart).AddDays(1);
            var endDate = DateTime.Today.AddDays(MasterlistAgeRange.InfantEnd);

            return await _repository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetMasterlistUnderFive(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveEnd);

            return await _repository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetMasterlistSchoolAge(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.SchoolAgedStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.SchoolAgedEnd);

            return await _repository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetMasterlistAdolescent(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.AdolescentStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.AdolescentEnd);

            return await _repository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetMasterlistAdult(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultEnd);

            return await _repository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetMasterlistSeniorCitizen(string householdNo)
        {
            var startDate = DateTime.MinValue; 
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.SeniorEnd);

            return await _repository.GetListQuery(householdNo, startDate, endDate);
        }
    }
}
