using System;

namespace ProjectEuler
{
    class Problem25 : BaseProblem
    {
        /*
         * The Fibonacci sequence is defined by the recurrence relation:
         * 
         * Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
         * 
         * Hence the first 12 terms will be:
         * F1 = 1
         * F2 = 1
         * F3 = 2
         * F4 = 3
         * F5 = 5
         * F6 = 8
         * F7 = 13
         * F8 = 21
         * F9 = 34
         * F10 = 55
         * F11 = 89
         * F12 = 144
         * 
         * The 12th term, F12, is the first term to contain three digits.
         * 
         * What is the index of the first term in the Fibonacci sequence to contain 1000 digits?
         */

        public Problem25(int problemNumber, long inputParam, string outputTemplate)
            : base(problemNumber, inputParam, outputTemplate)
        {
        }

        protected override long Solve()
        {
            /*
             * Using Binet formula:
             * 
             * //an = [ Phi^n - (phi)^n ]/Sqrt[5]
             * 
             * For approximation we can discard (phi)n, as it becomes very small for large n.
             * Thus we have to find the first n satisfying the following condition:
             * 
             * Phi^n/Sqrt[5] > 10^999,
             * 
             * or
             * 
             * log10(Phi^n) - log10(Sqrt[5]) > 999,
             * 
             * or
             * 
             * n*log10(Phi) - log10(Sqrt[5]) > 999
             */
            return
                Convert.ToInt64(
                    Math.Round(
                        (InputParam - 1 + Math.Log10(Math.Pow(5, 2)) - 1) / Math.Log10(Constants.Phi)
                    )
                );

        }
    }
}
