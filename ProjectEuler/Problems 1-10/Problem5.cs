using System.Collections.Generic;

namespace ProjectEuler
{
    /*
     * 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
     * What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
     */

    internal class Problem5 : BaseProblem
    {
        public Problem5(int problemNumber, long maxNumber, string outputTemplate)
            : base(problemNumber, maxNumber, outputTemplate)
        {
        }

        protected override long Solve()
        {
            long minDivisible = 1;

            List<int> primes = new List<int>();

            //We are going to build a complete list of all prime factors for all integers from 2 to MaxNumber
            for (int factor = 2; factor <= InputParam; factor++)
            {
                int tmpFactor = factor;

                foreach (var existingPrime in primes)
                {
                    var tmpRemainder = tmpFactor % existingPrime;
                    if (tmpRemainder == 0)
                    {
                        tmpFactor = tmpFactor / existingPrime;
                    }
                    if (tmpFactor == 1) break;
                }
                if (CommonFunctions.IsPrime(tmpFactor))
                {
                    primes.Add(tmpFactor);
                    minDivisible *= tmpFactor;
                }
            }
            return minDivisible;
        }
    }
}
