using AUF.EMR.Application.Contracts.Persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface ISummaryRepository
    {
        Task<int> GetCheckedPatientsToday(Guid id, DateTime startDate, DateTime endDate);
    }
}
