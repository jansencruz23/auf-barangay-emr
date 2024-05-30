using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface IPregnancyRecordRepository : IGenericRepository<PregnancyRecord>
    {
        Task<List<PregnancyRecord>> GetPregnancyRecordsWithDetails(string householdNo);
        Task<PregnancyRecord> GetPregnancyRecordWithDetails(int id);
        Task<List<PregnancyRecord>> GetPregnancyRecordForm(int id);
    }
}
