using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface ISummaryRepository
    {
        Task<int> GetCreatedFormsCount(FormType formType, DateTime startDate, DateTime endDate, Guid userId);
        Task<int> GetModifiedFormsCount(FormType formType, DateTime startDate, DateTime endDate, Guid userId);
        Task<int> GetTotalFormsCount(DateTime startDate, DateTime endDate, Guid userId);
    }
}
