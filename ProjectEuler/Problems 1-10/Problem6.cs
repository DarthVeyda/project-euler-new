namespace ProjectEuler
{
    /* Find the difference between the sum of the squares of the 
     * first one hundred natural numbers and the square of the sum.
     */

    internal class Problem6 : BaseProblem
    {
        public Problem6(int problemNumber, long count, string outputTemplate)
            : base(problemNumber, count, outputTemplate)
        {
        }

        protected override long Solve()
        {
            long diff = 0;

            for (int i = 1; i <= InputParam; i++)
                for (int j = 1; j <= InputParam; j++)
                {
                    if (i != j)
                        diff += i * j;
                }
            return diff;
        }
    }
}
