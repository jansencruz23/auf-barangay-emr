using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Services
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;

        public RecordService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public async Task<IReadOnlyList<RecordLog>> GetRecords(DateTime startTime, DateTime endTime)
        {
            return await _recordRepository.GetRecords(startTime, endTime);
        }
    }
}
