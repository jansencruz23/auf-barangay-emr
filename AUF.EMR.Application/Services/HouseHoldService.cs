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
    public class HouseHoldService : GenericService<HouseHold>, IHouseHoldService
    {
        private readonly IHouseHoldRepository _repository;

        public HouseHoldService(IHouseHoldRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public Task<List<HouseHold>> GetHouseHoldsWithDetails()
        {
            return _repository.GetHouseHoldsWithDetails();
        }

        public Task<HouseHold> GetHouseHoldWithDetails(int id)
        {
            return _repository.GetHouseHoldWithDetails(id);
        }
    }
}
