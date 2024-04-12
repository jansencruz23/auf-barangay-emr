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
        Task<int> GetHouseholdMemberCount();
        Task<int> GetMemberByAgeCount(DateTime startDate, DateTime endDate); 
        Task<int> GetMemberByAgeCount(string householdNo, DateTime startDate, DateTime endDate);
        Task<int> GetHouseholdMemberCount(string householdNo);
    }
}
