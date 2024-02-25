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
    public class HouseHoldService : GenericService<Household>, IHouseHoldService
    {
        private readonly IHouseHoldRepository _repository;

        public HouseHoldService(IHouseHoldRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<int> GetHouseHoldId(string houseHoldNo)
        {
            return await _repository.GetHouseHoldId(houseHoldNo);
        }

        public async Task<List<Household>> GetHouseHoldsWithDetails()
        {
            return await _repository.GetHouseHoldsWithDetails();
        }

        public async Task<Household> GetHouseHoldWithDetails(int id)
        {
            return await _repository.GetHouseHoldWithDetails(id);
        }

        public async Task<List<Household>> GetSearchedHouseHoldsWithDetails(string query)
        {
            return await _repository.GetSearchedHouseHoldsWithDetails(query);
        }

        public async Task<List<Household>> GetSearchedHouseHoldWithDetails(string query)
        {
            return await _repository.GetSearchedHouseHoldWithDetails(query);
        }
    }
}
