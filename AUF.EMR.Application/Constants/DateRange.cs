using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Constants
{
    public class DateRange
    {
        public static DateTime TodayStart => DateTime.Today;
        public static DateTime TodayEnd => DateTime.Today.AddDays(1).AddTicks(-1);

        public static DateTime WeekStart => DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
        public static DateTime WeekEnd => WeekStart.AddDays(7).AddTicks(-1);

        public static DateTime MonthStart => new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        public static DateTime MonthEnd => MonthStart.AddMonths(1).AddTicks(-1);

        public static DateTime YearStart => new DateTime(DateTime.Today.Year, 1, 1);
        public static DateTime YearEnd => new DateTime(DateTime.Today.Year, 12, 31).AddDays(1).AddTicks(-1);
    }
}
