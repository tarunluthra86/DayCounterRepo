using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayCounter
{
    public class Program
    {
        public static void Main(string[] args)
        {

            try
            {
                var bdCounterObj = new BusinessDayCounter();
                //Task 1
                var weekdaysCount = bdCounterObj.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 1, 1));

                //Task 2
                var publicHolidays = new List<DateTime>()
                                    { new DateTime(2013, 12, 25), new DateTime(2013, 12, 26), new DateTime(2014, 1, 1)};

                var businessDaysCount = bdCounterObj.BusinessDaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1), publicHolidays);


                //Task 3
                var moreHolidays = new List<PublicHoliday>()
                                    { new PublicHoliday("Anzac Day",25,4)
                                    ,new PublicHoliday("New Year", 1, 1 )
                                    ,new PublicHoliday("Queen's Birthday", DayOfWeek.Monday, 2, 6)
                                    };
                var businessDaysWithPublicHolidays = bdCounterObj.BusinessDaysBetweenTwoDates(new DateTime(2020, 12, 31), new DateTime(2021, 9, 30), moreHolidays);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception has occured with following message " + ex.Message);
            }
            
        }
    }
}
