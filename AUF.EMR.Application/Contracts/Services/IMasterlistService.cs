using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IMasterlistService : IGenericService<HouseholdMember>
    {
        Task<List<HouseholdMember>> GetAllMasterlist(string householdNo);
        Task<List<HouseholdMember>> GetMasterlistNewborn(string householdNo);
        Task<List<HouseholdMember>> GetMasterlistInfant(string householdNo);
        Task<List<HouseholdMember>> GetMasterlistUnderFive(string householdNo);
        Task<List<HouseholdMember>> GetMasterlistSchoolAge(string householdNo);
        Task<List<HouseholdMember>> GetMasterlistAdolescent(string householdNo);
        Task<List<HouseholdMember>> GetMasterlistAdult(string householdNo);
        Task<List<HouseholdMember>> GetMasterlistSeniorCitizen(string householdNo);
    }
}
