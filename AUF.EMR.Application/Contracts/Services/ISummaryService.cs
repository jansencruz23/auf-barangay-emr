using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface ISummaryService 
    {
        Task<int> GetFormsCount(FormType formType, DateRange dateRange, Guid userId);
        Task<int> GetModifiedFormsCount(FormType formType, DateRange dateRange, Guid userId);
        Task<int> GetTotalFormsCount(DateRange dateRange, Guid userId);
        Task<int> GetTotalFormsCount(DateRange dateRange, int offset, Guid userId);
    }
}