using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface IHouseHoldRepository : IGenericRepository<Household>
    {
        Task<List<Household>> GetHouseHoldsWithDetails();
        Task<List<Household>> GetSearchedHouseHoldsWithDetails(string query);
        Task<List<Household>> GetSearchedHouseHoldWithDetails(string query);
        Task<Household> GetHouseHoldWithDetails(int id);
        Task<int> GetHouseHoldId(string houseHoldNo);
    }
}
