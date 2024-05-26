using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IPatientRecordService : IGenericService<PatientRecord>
    {
        Task<List<PatientRecord>> GetPatientRecordsWithDetails(string householdNo);
        Task<PatientRecord> GetPatientRecordWithDetails(int id);
        Task<List<PatientRecord>> GetPatientRecordForm(int id);
    }
}
