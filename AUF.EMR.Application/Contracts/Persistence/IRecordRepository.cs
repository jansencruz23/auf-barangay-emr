using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface IRecordRepository
    {
        Task<IReadOnlyList<RecordLog>> GetRecords(DateTime startDate, DateTime endDate);
        Task<IReadOnlyList<RecordLog>> GetRecordsToday(Guid id);
    }
}
