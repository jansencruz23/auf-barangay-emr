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
    public class HouseholdMemberService : GenericService<HouseholdMember>, IHouseholdMemberService
    {
        private readonly IHouseholdMemberRepository _repository;

        public HouseholdMemberService(IHouseholdMemberRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<HouseholdMember>> GetHouseholdMembersWithDetails(string houseHoldNo)
        {
            return await _repository.GetHouseholdMembersWithDetails(houseHoldNo);
        }

        public async Task<HouseholdMember> GetHouseholdMemberWithDetails(int id)
        {
            return await _repository.GetHouseholdMemberWithDetails(id);
        }

        public async Task<List<HouseholdMember>> GetWRAHouseholdMember(string householdNo)
        {
            return await _repository.GetWRAHouseholdMember(householdNo);
        }
    }
}
