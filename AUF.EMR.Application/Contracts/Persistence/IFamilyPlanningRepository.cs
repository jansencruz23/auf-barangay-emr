using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface IFamilyPlanningRepository : IGenericRepository<FamilyPlanningRecord>
    {
        Task<FamilyPlanningRecord> GetFPRecordWithDetails(int id);
        Task<List<FamilyPlanningRecord>> GetFPRecordsWithDetails(string householdNo);
        Task<FamilyPlanningRecord> AddFamilyPlanning(FamilyPlanningRecord fpRecord);
    }
}
