using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface IHouseHoldMemberRepository : IGenericRepository<HouseHoldMember>
    {
        Task<List<HouseHoldMember>> GetHouseHoldMembersWithDetails(string houseHoldNo);
        Task<HouseHoldMember> GetHouseHoldMemberWithDetails(int id);
    }
}
