using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IHouseHoldService : IGenericService<HouseHold>
    {
        Task<List<HouseHold>> GetHouseHoldsWithDetails();
        Task<List<HouseHold>> GetSearchedHouseHoldsWithDetails(string query);
        Task<HouseHold> GetHouseHoldWithDetails(int id);
        Task<int> GetHouseHoldId(string houseHoldNo);
    }
}
