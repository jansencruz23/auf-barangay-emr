using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IPregnancyRecordService : IGenericService<PregnancyRecord>
    {
        Task<List<PregnancyRecord>> GetPregnancyRecordsWithDetails(string householdNo);
        Task<PregnancyRecord> GetPregnancyRecordWithDetails(int id);
        Task<List<PregnancyRecord>> GetPregnancyRecordForm(int id);
    }
}