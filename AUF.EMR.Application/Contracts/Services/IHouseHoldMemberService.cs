using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IHouseHoldMemberService : IGenericService<HouseholdMember>
    {
        Task<List<HouseholdMember>> GetHouseHoldMembersWithDetails(string houseHoldNo);
        Task<HouseholdMember> GetHouseHoldMemberWithDetails(int id);
    }
}
