using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IRecordService
    {
        Task<IReadOnlyList<RecordLog>> GetRecords(DateTime startTime, DateTime endTime);
    }
}
