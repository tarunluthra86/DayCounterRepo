using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayCounter
{
    public class BusinessDayCounter
    {       

        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            if (firstDate >= secondDate) return 0;
            int daysBetweenTwoDates = Convert.ToInt32((secondDate - firstDate).TotalDays);

            int weekendDays = (2 * ((daysBetweenTwoDates + Convert.ToInt32(firstDate.DayOfWeek)) / 7)) 
                - (firstDate.DayOfWeek == DayOfWeek.Saturday ? 1 : 0);
                

            return (daysBetweenTwoDates - 1) - weekendDays;

        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            if (firstDate >= secondDate) return 0;
            var weekDaysBetweenTwoDates = WeekdaysBetweenTwoDates(firstDate, secondDate);
            foreach (DateTime holidayDate in publicHolidays)
            {
                if ((holidayDate.DayOfWeek != DayOfWeek.Saturday || holidayDate.DayOfWeek != DayOfWeek.Sunday)
                    && firstDate < holidayDate && secondDate > holidayDate)
                    weekDaysBetweenTwoDates--;
            }
            return weekDaysBetweenTwoDates;
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<PublicHoliday> publicHolidays)
        {
            if (firstDate >= secondDate) return 0;
            var weekDaysBetweenTwoDates = WeekdaysBetweenTwoDates(firstDate, secondDate);
            foreach (PublicHoliday holidayDate in publicHolidays)
            {
                if ((holidayDate.Date.DayOfWeek != DayOfWeek.Saturday || holidayDate.Date.DayOfWeek != DayOfWeek.Sunday)
                    && firstDate < holidayDate.Date && secondDate > holidayDate.Date)
                    weekDaysBetweenTwoDates--;
            }
            return weekDaysBetweenTwoDates;
        }

    }
}
