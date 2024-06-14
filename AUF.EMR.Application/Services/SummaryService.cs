using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services.Common;
using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly ISummaryRepository _repository;

        public SummaryService(ISummaryRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> GetCreatedFormsCount(FormType formType, DateRange dateRange, Guid userId)
        {
            DateTime startDate = GetStartingDate(dateRange);
            DateTime endDate = DateTime.Now;

            int count = await _repository.GetCreatedFormsCount(formType, startDate, endDate, userId);
            return count;
        }
        
        private DateTime GetStartingDate(DateRange dateRange)
        {
            return dateRange switch
            {
                DateRange.Daily => DateTime.Today,
                DateRange.Weekly => DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek),
                DateRange.Monthly => new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                DateRange.Yearly => new DateTime(DateTime.Now.Year, 1, 1),
                _ => throw new ArgumentOutOfRangeException(nameof(DateRange), dateRange, null),
            };
        }

        public async Task<int> GetModifiedFormsCount(FormType formType, DateRange dateRange, Guid userId)
        {
            DateTime startDate = GetStartingDate(dateRange);
            DateTime endDate = DateTime.Now;

            int count = await _repository.GetModifiedFormsCount(formType, startDate, endDate, userId);
            return count;
        }

        public async Task<int> GetTotalFormsCount(DateRange dateRange, Guid userId)
        {
            DateTime startDate = GetStartingDate(dateRange);
            DateTime endDate = DateTime.Now;

            int count = await _repository.GetTotalFormsCount(startDate, endDate, userId);
            return count;
        }
    }
}
