using AUF.EMR.Application.Constants;
using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services.Common;
using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models;
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

        public async Task DeleteHouseholdMember(int id)
        {
            await _repository.DeleteHouseholdMember(id);
        }

        public string GetClassifications(List<Classification> classifications)
        {
            var keyList = new StringBuilder();
            return keyList.AppendJoin(",", classifications
                .Where(c => c.Selected)
                .Select(c => c.Key)).ToString();
        }

        public async Task<List<HouseholdMember>> GetHouseholdMembersWithDetails(string houseHoldNo)
        {
            return await _repository.GetHouseholdMembersWithDetails(houseHoldNo);
        }

        public async Task<HouseholdMember> GetHouseholdMemberWithDetails(int id)
        {
            return await _repository.GetHouseholdMemberWithDetails(id);
        }

        public async Task<List<HouseholdMember>> GetWRAHouseholdMembers(string householdNo)
        {
            return await _repository.GetWRAHouseholdMembers(householdNo);
        }
    }
}
