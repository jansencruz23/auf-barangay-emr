using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface IPregnancyTrackingRepository : IGenericRepository<PregnancyTracking>
    {
        Task<List<PregnancyTracking>> GetPregnancyTrackingListWithDetails(string householdNo);
        Task<PregnancyTracking> GetPregnancyTrackingWithDetails(int id);
        Task<List<HouseholdMember>> GetPregnantHouseholdMembers(string householdNo, DateTime startDate, DateTime endDate);
    }
}
