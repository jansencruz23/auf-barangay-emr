using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Validations
{
    public class DateAttribute : RangeAttribute
    {
        public DateAttribute()
        : base(typeof(DateTime), DateTime.Now.AddYears(-100).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture), 
              DateTime.Now.AddYears(2).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)) { }
    }
}
