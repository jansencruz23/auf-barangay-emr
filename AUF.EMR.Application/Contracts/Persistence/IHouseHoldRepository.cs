using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface IHouseholdRepository : IGenericRepository<Household>
    {
        Task<string> GetHouseholdNo(int id);
        Task<List<Household>> GetHouseholdsWithDetails();
        Task<List<Household>> GetSearchedHouseholdsWithDetails(string query);
        Task<Household> GetSearchedHouseholdWithDetails(string query);
        Task<Household> GetHouseholdWithDetails(int id);
        Task<Household> GetHouseholdWithDetails(string householdNo);
        Task<int> GetHouseholdId(string householdNo);
        Task<bool> IsHouseholdNoExisting(string householdNo);
        Task DeleteHousehold(int id);
    }
}
