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

        public Task<List<HouseholdMember>> GetMasterlistInfant(string householdNo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HouseholdMember>> GetMasterlistNewborn(string householdNo)
        {
            var startDate = DateTime.Today.AddDays(MasterlistAgeRange.NEWBORN);
            return await _repository.GetMasterlistQuery(householdNo, startDate);
        }

        public Task<List<HouseholdMember>> GetMasterlistSchoolAge(string householdNo)
        {
            throw new NotImplementedException();
        }

        public Task<List<HouseholdMember>> GetMasterlistSeniorCitizen(string householdNo)
        {
            throw new NotImplementedException();
        }

        public Task<List<HouseholdMember>> GetMasterlistUnderFive(string householdNo)
        {
            throw new NotImplementedException();
        }
    }
}
