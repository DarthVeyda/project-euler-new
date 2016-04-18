using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    internal class Problem26 : BaseProblem
    {
        /*
         * A unit fraction contains 1 in the numerator. The decimal representation 
         * of the unit fractions with denominators 2 to 10 are given:
         * 
         * 1/2	= 	0.5
         * 1/3	= 	0.(3)
         * 1/4	= 	0.25
         * 1/5	= 	0.2
         * 1/6	= 	0.1(6)
         * 1/7	= 	0.(142857)
         * 1/8	= 	0.125
         * 1/9	= 	0.(1)
         * 1/10	= 	0.1
         * 
         * Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. 
         * It can be seen that 1/7 has a 6-digit recurring cycle.
         * Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
         */

        public Problem26(int problemNumber, long inputParam, string outputTemplate)
            : base(problemNumber, inputParam, outputTemplate)
        {
        }

        protected override long Solve()
        {
            /*
             * We have to check only primes below 1000 - composite numbers 
             * cannot have cycleslonger than their prive factors.
             * That is, we need to find the largest prime below 1000
             * for which its decimal fraction part is a cyclic number
             */
            var primesToCheck = Constants.Primes.OrderByDescending(x => x).ToList();

            foreach (var prime in primesToCheck)
            {
                BigInteger testCycle = BigInteger.Pow(10, prime - 1) - 1;
                BigInteger remainder;
                var result = BigInteger.DivRem(testCycle, new BigInteger(prime), out remainder);

                // We need a full (prime-1)-digit sequence for premutetions 
                string resultStr = Utility.PadWithZeroes(result, prime - 1);

                /*
                 * By definition, a cyclic number is an integer in which cyclic permutations 
                 * of the digits are successive multiples of the number. 
                 */
                var dividers = Enumerable.Range(1, prime - 1).Select(x => new BigInteger(x)).ToList();

                for (int shift = 2; shift <= prime; shift++)
                {
                    var tmpResult = BigInteger.DivRem(BigInteger.Parse(Utility.ShiftString(resultStr, shift - 1)), result, out remainder);
                    if (dividers.Contains(tmpResult)) dividers.Remove(tmpResult);
                }
                /*
                 * If there are integers in 1..prime-1 range that cannot be 
                 * presented as (permutation)/(number), the number is not cyclic
                 */
                if (dividers.Any()) continue;

                return prime;
            }
            return -1;
        }


    }
}
