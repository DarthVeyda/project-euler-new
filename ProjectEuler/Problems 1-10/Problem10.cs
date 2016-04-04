using System.Linq;

namespace ProjectEuler
{
    /*
     * The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
     * Find the sum of all the primes below two million. 
     */

    internal class Problem10 : BaseProblem
    {
        public Problem10(int problemNumber, long max, string outputTemplate)
            : base(problemNumber, max, outputTemplate)
        {
        }

        protected override long Solve()
        {
            return (long)Enumerable.Range(1, (int)InputParam - 1)
                                       .Where(i => CommonFunctions.IsPrime((long)i)).Select(i => (long)i)
                                       .Sum(i => (decimal)i);
        }
    }
}
