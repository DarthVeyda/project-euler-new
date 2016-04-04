using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    internal class Problem19 : BaseProblem
    {
        /*
         * You are given the following information, but you may prefer to do some research for yourself.
         * 1 Jan 1900 was a Monday.
         * 
         * Thirty days has September,
         * April, June and November.
         * All the rest have thirty-one,
         * Saving February alone,
         * Which has twenty-eight, rain or shine.
         * And on leap years, twenty-nine.
         * 
         * A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
         * 
         * How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
         */

        private readonly byte[] _yearLayout = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

        public Problem19(int problemNumber, long inputParam, string outputTemplate)
            : base(problemNumber, inputParam, outputTemplate)
        {
        }

        protected override long Solve()
        {
            List<byte> days = new List<byte>();
            for (int year = 1901; year <= 2000; year++) //populate the "calendar" for the specified time period
            {
                for (int month = 1; month <= 12; month++)
                {
                    days.AddRange(Enumerable.Range(1, DateTime.DaysInMonth(year,month)).Select(x => (byte)x));
                }
                //for (byte month = 0; month < _yearLayout.Length; month++)
                //{
                //    var daysOfMonth = _yearLayout[month];
                //    if (0 == year%4) daysOfMonth++; //no check for century year because 
                //                                    //the only one we are going to hit is 2000
                //    days.AddRange(Enumerable.Range(1,daysOfMonth).Select(x=>(byte)x));
                //}
            }
                          //the weekday for 1st Jan 1901 
                          //          ↓
            byte weekShift = 7 - (365 % 7 + 1); // ← the number of days to skip to the first Sunday of 1901
            int sundayCount = 0;
            for (int sunday = weekShift; sunday <= days.Count; sunday += 7)
            {
                if (1 == days[sunday]) sundayCount++;
            }
            return sundayCount;
        }
    }
}
