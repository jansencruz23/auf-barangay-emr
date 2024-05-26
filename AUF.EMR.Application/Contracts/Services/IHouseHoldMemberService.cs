using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models;
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
        Task DeleteHouseholdMember(int id);
        string GetClassifications(List<Classification> classifications);
        Task<List<HouseholdMember>> GetHouseholdMemberForm(int id);
    }
}
