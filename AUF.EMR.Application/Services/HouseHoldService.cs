using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Persistence.Common;
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
    public class HouseholdService : GenericService<Household>, IHouseholdService
    {
        private readonly IHouseholdRepository _repository;

        public HouseholdService(IHouseholdRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public async Task DeleteHousehold(int id)
        {
            await _repository.DeleteHousehold(id);
        }

        public async Task<int> GetHouseholdId(string householdNo)
        {
            return await _repository.GetHouseholdId(householdNo);
        }

        public async Task<List<Household>> GetHouseholdsWithDetails()
        {
            return await _repository.GetHouseholdsWithDetails();
        }

        public async Task<Household> GetHouseholdWithDetails(int id)
        {
            return await _repository.GetHouseholdWithDetails(id);
        }

        public async Task<List<Household>> GetSearchedhouseHoldsWithDetails(string query)
        {
            return await _repository.GetSearchedHouseholdsWithDetails(query);
        }

        public async Task<List<Household>> GetSearchedhouseHoldWithDetails(string query)
        {
            return await _repository.GetSearchedHouseholdWithDetails(query);
        }

        public async Task<bool> IsHouseholdNoExisting(string householdNo)
        {
            return await _repository.IsHouseholdNoExisting(householdNo);
        }
    }
}
