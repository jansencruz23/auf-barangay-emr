using AUF.EMR.Application.Contracts.Persistence;
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
    public class HouseHoldMemberService : GenericService<HouseHoldMember>, IHouseHoldMemberService
    {
        private readonly IHouseHoldMemberRepository _repository;

        public HouseHoldMemberService(IHouseHoldMemberRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<HouseHoldMember>> GetHouseHoldMembersWithDetails(string houseHoldNo)
        {
            return await _repository.GetHouseHoldMembersWithDetails(houseHoldNo);
        }

        public async Task<HouseHoldMember> GetHouseHoldMemberWithDetails(int id)
        {
            return await _repository.GetHouseHoldMemberWithDetails(id);
        }
    }
}
