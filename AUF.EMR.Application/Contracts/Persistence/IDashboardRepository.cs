using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface IDashboardRepository
    {
        Task<int> GetHouseholdCount();
        Task<int> GetHouseholdCount(int days);
        Task<int> GetHouseholdCount(int days, int daysDeleted);
        Task<int> GetHouseholdMemberCount();
        Task<int> GetMemberByAgeCount(DateTime startDate, DateTime endDate); 
        Task<int> GetMemberByAgeCount(string householdNo, DateTime startDate, DateTime endDate);
        Task<int> GetHouseholdMemberCount(string householdNo);
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
        Task<int> GetDiabetesRiskRecordCount();
        Task<int> GetDiabetesRiskRecordCount(string householdNo);
    }
}
