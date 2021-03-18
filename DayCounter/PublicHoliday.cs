using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayCounter
{
    public class PublicHoliday
    {
        private int Year { get { return DateTime.Now.Year; } }
        public PublicHoliday(string name, DateTime date)
        {
            Name = name;
            Date = GetBusinessDate(date);
        }

        public PublicHoliday(string name, int date, int month)
        {
            Name = name;
            Date = GetBusinessDate(new DateTime(Year,month,date));
        }

        public PublicHoliday(string name, DayOfWeek dayOfWeek, int occurence, int month)
        {
            Name = name;
            var date = GetDateForGivenWeekdayOccurence(dayOfWeek,occurence,month);
            Date = GetBusinessDate(date);
        }

        public string Name { get; set; }
        public DateTime Date { get; set; }

        private DateTime GetBusinessDate(DateTime date)
        {
            //TODO:This method doesnt take into account when there are two consecutive holidays over weekend
            if (date.DayOfWeek == DayOfWeek.Saturday)
                return date.AddDays(2);
            else if (date.DayOfWeek == DayOfWeek.Sunday)
                return date.AddDays(1);
            else
                return date;
        }

        private DateTime GetDateForGivenWeekdayOccurence(DayOfWeek dayOfWeek, int occurence, int month)
        {
            if (occurence < 1 || occurence > 5) throw new ArgumentOutOfRangeException("occurence", "Should be between 1 to 5");

            var firstDay = new DateTime(Year, month, 1);

            while (firstDay.DayOfWeek != dayOfWeek)
            {
                firstDay = firstDay.AddDays(1);
            }

            return firstDay.AddDays((occurence - 1) * 7);
        }


    }
}
