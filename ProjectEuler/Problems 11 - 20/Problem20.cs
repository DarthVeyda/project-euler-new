using System.Numerics;
using System.Linq;

namespace ProjectEuler
{
    internal class Problem20 : BaseProblem
    {
        /*
         * n! means n × (n − 1) × ... × 3 × 2 × 1
         * For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
         * and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
         * Find the sum of the digits in the number 100!
         */
        public Problem20(int problemNumber, long number, string outputTemplate)
            : base(problemNumber, number, outputTemplate)
        {
        }

        protected override long Solve()
        {
            BigInteger ourNumber = new BigInteger(1);
            for (int i = 1; i <= InputParam; i++) ourNumber *= i;
            return ourNumber.ToString().Sum(el => long.Parse(el.ToString()));
        }
    }
}
