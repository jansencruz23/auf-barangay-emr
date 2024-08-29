using AUF.EMR.Application.Common;
using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services.Common;
using AUF.EMR.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage;
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

        public async Task<string> GetHouseholdNo(int id)
        {
            return await _repository.GetHouseholdNo(id);
        }

        public async Task DeleteHousehold(int id)
        {
            await _repository.DeleteHousehold(id);
        }

        public async Task<int> GetHouseholdId(string householdNo)
        {
            return await _repository.GetHouseholdId(householdNo);
        }

        public async Task<PaginatedList<Household>> GetHouseholdsWithDetails(int page)
        {
            return await _repository.GetHouseholdsWithDetails(page);
        }

        public async Task<Household> GetHouseholdWithDetails(int id)
        {
            return await _repository.GetHouseholdWithDetails(id);
        }

        public async Task<PaginatedList<Household>> GetSearchedhouseHoldsWithDetails(string query, int page)
        {
            return await _repository.GetSearchedHouseholdsWithDetails(query, page);
        }

        public async Task<Household> GetSearchedhouseHoldWithDetails(string householdNo)
        {
            return await _repository.GetSearchedHouseholdWithDetails(householdNo);
        }

        public async Task<bool> IsHouseholdNoExisting(string householdNo)
        {
            return await _repository.IsHouseholdNoExisting(householdNo);
        }

        public async Task<Household> GetHouseholdWithDetails(string householdNo)
        {
            return await _repository.GetHouseholdWithDetails(householdNo);
        }

        public async Task<List<Household>> GetHouseholdForm(string householdNo)
        {
            var form = new List<Household>();
            var household = await _repository.GetHouseholdWithDetails(householdNo);
            form.Add(household);

            return form;
        }
    }
}
