using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    /*
     * Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, 
     * there are exactly 6 routes to the bottom right corner.
     * How many such routes are there through a 20×20 grid?
     */

    internal class Problem15 : BaseProblem
    {
        public Problem15(int problemNumber, long gridSize, string outputTemplate)
            : base(problemNumber, gridSize, outputTemplate)
        {
        }

        protected override long Solve()
        {
            /*
             * If we look at the diagonal nodes and number them from 1 to N+1, where N is the grid size,
             * then for each Kth node there is exactly P(K,N) ways to get from top left corner to that node,
             * where P(K,N) is the Kth element in the Nth line of Pascal triangle, K = 1..N+1
             * Similarly, there's P(K,N) ways to get from the Kth node to the bottom right corner.
             * Hence the total number of routes is P(1,N)^2 + ... + P(N+1,N)^2
             * (e.g. 1*1 + 2*2 + 1*1 = 6 for the 2x2 grid)
             */
            return PascalTriangleLine(InputParam).Sum(element => element*element);
        }

        public void TestOutput(long lineNumber)
        {
            Console.WriteLine(string.Join(" ", PascalTriangleLine(lineNumber)));
        }

        private IEnumerable<long> PascalTriangleLine(long lineNumber)
        {
            yield return 1;
            long currElement = 1;
            for (int k = 1; k <= lineNumber; k++)
            {
                yield return currElement * (lineNumber + 1 - k) / k;
                currElement = currElement * (lineNumber + 1 - k) / k;
            }
        }
    }
}
