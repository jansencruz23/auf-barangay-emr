using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IOralHealthService : IGenericService<HouseholdMember>
    {
        Task<List<HouseholdMember>> GetAllOralClients(string householdNo);
        Task<List<HouseholdMember>> GetOralClientInfant(string householdNo);
        Task<List<HouseholdMember>> GetOralClient1to4(string householdNo);
        Task<List<HouseholdMember>> GetOralClient5to9(string householdNo);
        Task<List<HouseholdMember>> GetOralClient10to14(string householdNo);
        Task<List<HouseholdMember>> GetOralClient15to19(string householdNo);
        Task<List<HouseholdMember>> GetOralClient20to49(string householdNo);
        Task<List<HouseholdMember>> GetOralClientPregnant15to19(string householdNo);
        Task<List<HouseholdMember>> GetOralClientPregnant20to49(string householdNo);
    }
}
