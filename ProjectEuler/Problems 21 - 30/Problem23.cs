using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    internal class Problem23 : BaseProblem
    {
        /*
         * A perfect number is a number for which the sum of its proper divisors is 
         * exactly equal to the number. For example, the sum of the proper divisors of 28 
         * would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
         * 
         * A number n is called deficient if the sum of its proper divisors is less than n 
         * and it is called abundant if this sum exceeds n.
         * 
         * As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number 
         * that can be written as the sum of two abundant numbers is 24. By mathematical analysis, 
         * it can be shown that all integers greater than 28123 (actually 20161, see 
         * https://en.wikipedia.org/wiki/Abundant_number#Properties) can be written as the sum of 
         * two abundant numbers. However, this upper limit cannot be reduced any further by analysis 
         * even though it is known that the greatest number that cannot be expressed as the sum of 
         * two abundant numbers is less than this limit.
         * 
         * Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
         */

        public Problem23(int problemNumber, long maxNumber, string outputTemplate)
            : base(problemNumber, maxNumber, outputTemplate)
        {
        }

        protected override long Solve()
        {
            List<int> result = Enumerable.Range(1, (int)InputParam).ToList();
            List<int> abundants = new List<int>();
            for (int number = 12; number <= InputParam; number++)
            {
                var divisors = CommonFunctions.SmarterGetAllFactors(number);
                divisors.Remove(number);
                if (number < divisors.Sum())
                {
                    abundants.Add(number);
                }
            }
            foreach (var abundant in abundants)
            {
                foreach (var i in abundants)
                {
                    result.Remove(abundant + i);
                }
            }
            return result.Sum();
        }
    }
}
