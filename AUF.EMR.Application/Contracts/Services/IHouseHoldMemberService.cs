using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IHouseholdMemberService : IGenericService<HouseholdMember>
    {
        Task<List<HouseholdMember>> GetHouseholdMembersWithDetails(string houseHoldNo);
        Task<HouseholdMember> GetHouseholdMemberWithDetails(int id);
        Task<List<HouseholdMember>> GetWRAHouseholdMembers(string householdNo);
        Task<List<HouseholdMember>> GetMenHouseholdMembers(string householdNo);
        Task DeleteHouseholdMember(int id);
    }
}
