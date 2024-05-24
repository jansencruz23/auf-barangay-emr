using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IDashboardService
    {
        Task<int> GetHouseholdCount();
        Task<int> GetHouseholdMemberCount();
        Task<int> GetHouseholdMemberCount(string householdNo);
        Task<int> GetNewbornCount();
        Task<int> GetNewbornCount(string householdNo);
        Task<int> GetInfantCount();
        Task<int> GetInfantCount(string householdNo);
        Task<int> GetUnderFiveCount();
        Task<int> GetUnderFiveCount(string householdNo);
        Task<int> GetSchoolAgedCount();
        Task<int> GetSchoolAgedCount(string householdNo);
        Task<int> GetAdolescentCount();
        Task<int> GetAdolescentCount(string householdNo);
        Task<int> GetAdultsCount();
        Task<int> GetAdultsCount(string householdNo);
        Task<int> GetSeniorCount();
        Task<int> GetSeniorCount(string householdNo);
        Task<int> GetPregnantCount();
        Task<int> GetPregnantCount(string householdNo);
        Task<int> GetWRAFormCount();
        Task<int> GetWRAFormCount(string householdNo);
        Task<int> GetPregnancyTrackingFormCount();
        Task<int> GetPregnancyTrackingFormCount(string householdNo);
        Task<int> GetFamilyPlanningFormCount();
        Task<int> GetFamilyPlanningFormCount(string householdNo);
        Task<int> GetPatientRecordCount();
        Task<int> GetPatientRecordCount(string householdNo);
        Task<int> GetPregnancyRecordCount();
        Task<int> GetPregnancyRecordCount(string householdNo);
    }
}
