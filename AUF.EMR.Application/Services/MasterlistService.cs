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

        public Task<List<HouseholdMember>> GetMasterlistAdolescent(string householdNo)
        {
            throw new NotImplementedException();
        }

        public Task<List<HouseholdMember>> GetMasterlistAdult(string householdNo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HouseholdMember>> GetMasterlistNewborn(string householdNo)
        {
            var startDate = DateTime.Today.AddDays(MasterlistAgeRange.NewbornStart);
            return await _repository.GetMasterlistQuery(householdNo, startDate);
        }

        public async Task<List<HouseholdMember>> GetMasterlistInfant(string householdNo)
        {
            var startDate = DateTime.Today.AddMonths(MasterlistAgeRange.InfantStart)
                .AddDays(MasterlistAgeRange.Month);
            var endDate = DateTime.Today.AddDays(MasterlistAgeRange.InfantStart);

            return await _repository.GetMasterlistQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetMasterlistUnderFive(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveStart);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveEnd);

            return await _repository.GetMasterlistQuery(householdNo, startDate, endDate);
        }

        public Task<List<HouseholdMember>> GetMasterlistSchoolAge(string householdNo)
        {
            throw new NotImplementedException();
        }

        public Task<List<HouseholdMember>> GetMasterlistSeniorCitizen(string householdNo)
        {
            throw new NotImplementedException();
        }
    }
}
