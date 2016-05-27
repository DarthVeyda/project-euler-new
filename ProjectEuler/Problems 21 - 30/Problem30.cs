using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Problem30 : BaseProblem
    {
        /*
         * Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:
         * 
         * 1634 = 1^4 + 6^4 + 3^4 + 4^4
         * 8208 = 8^4 + 2^4 + 0^4 + 8^4
         * 9474 = 9^4 + 4^4 + 7^4 + 4^4
         * 
         * As 1 = 1^4 is not a sum it is not included.
         * 
         * The sum of these numbers is 1634 + 8208 + 9474 = 19316.
         * 
         * Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
         */
        public Problem30(int problemNumber, long inputParam, string outputTemplate)
            : base(problemNumber, inputParam, outputTemplate)
        {
        }
        protected override long Solve()
        {
            // The numbers above 9^5*6 = 354294 cannot be written as the sum of fifth powers of their digits
            // (9^5*7 = 413343 has 6 digits)

            List<double> list = new List<double>();
            for (int number = 10; number <= 354294; number++)
            {
                if (number == ExtensionMethods.Digits(number).Aggregate(0, (current, next) => current + (int)Math.Pow(next, InputParam))) list.Add(number);
            }
            return (long)list.Sum();
        }
    }

}
