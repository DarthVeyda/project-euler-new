using System.Linq;

namespace ProjectEuler
{
    internal class Problem21 : BaseProblem
    {
        /*
         * Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
         * If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair 
         * and each of a and b are called amicable numbers.
         * 
         * For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; 
         * therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
         * 
         * Evaluate the sum of all the amicable numbers under 10000.
         */

        public Problem21(int problemNumber, long inputParam, string outputTemplate)
            : base(problemNumber, inputParam, outputTemplate)
        {
        }

        protected override long Solve()
        {
            var divisorSums = Enumerable.Range(2, (int)InputParam) //pairs of all natural numbers up to InputParam 
                                                                   //and sums of their divisors
                .ToDictionary(x => (long)x, x => CommonFunctions.EvenSmarterGetAllFactors(x).Sum() - x);

            return
                divisorSums.Where(
                    divisorSum => // check if the current number has an amicable pair
                        divisorSums.Keys.Contains(divisorSum.Value) && (divisorSum.Key!=divisorSum.Value) && (divisorSums[divisorSum.Value] == divisorSum.Key))
                    .Sum(divisorSum => divisorSum.Key);
        }
    }
}
