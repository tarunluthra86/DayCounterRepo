using System;
using System.Collections.Generic;
using DayCounter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DayCounterTest
{
    [TestClass]
    public class BusinessDayCounterTest
    {
        readonly List<DateTime> publicHolidays = new List<DateTime>() { new DateTime(2013, 12, 25), new DateTime(2013, 12, 26), new DateTime(2014, 1, 1) };

        readonly List<PublicHoliday> moreHolidays = new List<PublicHoliday>()
                                    { new PublicHoliday("Anzac Day",25,4)
                                    ,new PublicHoliday("New Year", 1, 1 )
                                    ,new PublicHoliday("Queen's Birthday", DayOfWeek.Monday, 2, 6)
                                    };

        [TestMethod]
        public void Task1_OneWeekDayInBetween()
        {
            var dayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2013, 10, 7);
            var secondDate = new DateTime(2013, 10, 9);
            Assert.AreEqual(1, dayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate));
        }

        [TestMethod]
        public void Task1_FiveWeekDaysInBetween()
        {
            var dayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2013, 10, 5);
            var secondDate = new DateTime(2013, 10, 14);
            Assert.AreEqual(5, dayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate));
        }

        [TestMethod]
        public void Task1_MultipleWeekDaysInBetween()
        {
            var dayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2013, 10, 7);
            var secondDate = new DateTime(2014, 1, 1);
            Assert.AreEqual(61, dayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate));
        }

        [TestMethod]
        public void Task1_ZeroDaysInBetween()
        {
            var dayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2013, 10, 7);
            var secondDate = new DateTime(2013, 10, 5);
            Assert.AreEqual(0, dayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate));
        }

        [TestMethod]
        public void Task2_OneBusinessDayInBetween()
        {
            var dayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2013, 10, 7);
            var secondDate = new DateTime(2013, 10, 9);
            Assert.AreEqual(1, dayCounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays));
        }

        [TestMethod]
        public void Task2_ZeroBusinessDaysInBetween()
        {
            var dayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2013, 12, 24);
            var secondDate = new DateTime(2013, 12, 27);
            Assert.AreEqual(0, dayCounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays));
        }

        [TestMethod]
        public void Task2_MultipleBusinessDaysInBetween()
        {
            var dayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2013, 10, 7);
            var secondDate = new DateTime(2014, 1, 1);
            Assert.AreEqual(59, dayCounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays));
        }

        [TestMethod]
        public void Task3_AnzacDay_BusinessDaysInBetween()
        {
            var dayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2021, 4, 20);
            var secondDate = new DateTime(2021, 4, 29);
            Assert.AreEqual(5, dayCounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, moreHolidays));
        }

        [TestMethod]
        public void Task3_NewYear_BusinessDaysInBetween()
        {
            var dayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2020, 12, 31);
            var secondDate = new DateTime(2021, 1, 27);
            Assert.AreEqual(17, dayCounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, moreHolidays));
        }

        [TestMethod]
        public void Task3_QueenBirthDay_BusinessDaysInBetween()
        {
            var dayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2021, 5, 21);
            var secondDate = new DateTime(2021, 7, 21);
            Assert.AreEqual(41, dayCounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, moreHolidays));
        }
    }
}
