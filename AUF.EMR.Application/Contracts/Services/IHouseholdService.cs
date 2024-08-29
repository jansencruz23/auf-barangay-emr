using AUF.EMR.Application.Common;
using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IHouseholdService : IGenericService<Household>
    {
        Task<string> GetHouseholdNo(int id);
        Task<PaginatedList<Household>> GetHouseholdsWithDetails(int page);
        Task<PaginatedList<Household>> GetSearchedhouseHoldsWithDetails(string query, int page);
        Task<Household> GetSearchedhouseHoldWithDetails(string query);
        Task<Household> GetHouseholdWithDetails(int id);
        Task<Household> GetHouseholdWithDetails(string householdNo);
        Task<int> GetHouseholdId(string householdNo);
        Task<bool> IsHouseholdNoExisting(string householdNo);
        Task DeleteHousehold(int id);
        Task<List<Household>> GetHouseholdForm(string householdNo);
    }
}
