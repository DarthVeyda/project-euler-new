using System;

namespace ProjectEuler
{
    /*
     * The prime factors of 13195 are 5, 7, 13 and 29.
     * What is the largest prime factor of the number 600851475143 ?
     */

    internal class Problem3 : BaseProblem
    {
        public Problem3(int problemNumber, long number, string outputTemplate)
            : base(problemNumber, number, outputTemplate)
        {
        }

        protected override long Solve() 
        {
            long maxFactor = 1;
            for (long p = Convert.ToInt64(Math.Truncate(Math.Sqrt(InputParam))); p >= 2; p--) 
            {
                if ((InputParam % p == 0) && ((p % 6 == 1) || (p % 6 == 5) || (p == 3) || (p == 2))) 
                {
                    if (CommonFunctions.IsPrime(p))
                    {
                        maxFactor = p;
                        break;
                    }
                }
            }
            return maxFactor;
        }
    }
}
