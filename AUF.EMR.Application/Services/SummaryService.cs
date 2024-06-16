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

        public async Task<int> GetFormsCount(FormType formType, DateRange dateRange, Guid userId)
        {
            var startDate = GetStartingDate(dateRange);
            var endDate = DateTime.Now;

            int createdCount = await _repository.GetCreatedFormsCount(formType, startDate, endDate, userId);
            int modifiedCount = await _repository.GetModifiedFormsCount(formType, startDate, endDate, userId);

            return createdCount + modifiedCount;
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
            var startDate = GetStartingDate(dateRange);
            var endDate = DateTime.Now;

            int count = await _repository.GetModifiedFormsCount(formType, startDate, endDate, userId);
            return count;
        }

        public async Task<int> GetTotalFormsCount(DateRange dateRange, Guid userId)
        {
            var startDate = GetStartingDate(dateRange);
            var endDate = DateTime.Now;

            int count = await _repository.GetTotalFormsCount(startDate, endDate, userId);
            return count;
        }

        public async Task<int> GetTotalFormsCount(DateRange dateRange, int offset, Guid userId)
        {
            DateTime startDate = GetStartingDateWithOffset(dateRange, offset -1);
            DateTime endDate = GetEndingDateWithOffset(dateRange, offset -1);

            int count = await _repository.GetTotalFormsCount(startDate, endDate, userId);
            return count;
        }

        private DateTime GetStartingDateWithOffset(DateRange dateRange, int offset)
        {
            DateTime startDate;
            switch (dateRange)
            {
                case DateRange.Daily:
                    startDate = DateTime.Today.AddDays(-offset);
                    break;
                case DateRange.Weekly:
                    startDate = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek + 7 * offset));
                    break;
                case DateRange.Monthly:
                    startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-offset);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dateRange), dateRange, null);
            }
            return startDate;
        }

        private DateTime GetEndingDateWithOffset(DateRange dateRange, int offset)
        {
            DateTime endDate;
            switch (dateRange)
            {
                case DateRange.Daily:
                    endDate = DateTime.Today.AddDays(-offset).AddDays(1).AddTicks(-1); // End of the day
                    break;
                case DateRange.Weekly:
                    endDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek - 7 * offset).AddDays(7).AddTicks(-1); // End of the week
                    break;
                case DateRange.Monthly:
                    endDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-offset + 1).AddTicks(-1); // End of the month
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dateRange), dateRange, null);
            }
            return endDate;
        }

        private int GetOffsetInDays(DateRange dateRange, int offset)
        {
            var offsetInDays = dateRange switch
            {
                DateRange.Daily => offset,
                DateRange.Weekly => offset * 7,
                DateRange.Monthly => offset * 30,// Approximate as 30 days for simplicity
                _ => throw new ArgumentOutOfRangeException(nameof(dateRange), dateRange, null),
            };
            return offsetInDays;
        }
    }
}
