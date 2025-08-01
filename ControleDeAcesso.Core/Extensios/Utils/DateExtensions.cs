using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Core.Extensios.Utils
{
    public static class DateExtensions
    {
        public static DateTime HorasTimeZone(this DateTime data)
        {
            TimeZoneInfo fusoHorarioAtual = TimeZoneInfo.Local;

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            if (fusoHorarioAtual.BaseUtcOffset.Hours != timeZone.BaseUtcOffset.Hours)
                return data.AddHours(timeZone.BaseUtcOffset.Hours);

            //data = data.AddHours(timeZone.BaseUtcOffset.Hours);
            return data;
        }
    }
}
