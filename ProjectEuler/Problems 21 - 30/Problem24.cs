using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Problem24 : BaseProblem
    {
        /*
         * A permutation is an ordered arrangement of objects. 
         * For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. 
         * If all of the permutations are listed numerically or alphabetically, 
         * we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
         * 
         *                012   021   102   120   201   210
         *                
         * What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
         */

        public Problem24(int problemNumber, long inputParam, string outputTemplate)
            : base(problemNumber, inputParam, outputTemplate)
        {
        }

        protected override long Solve()
        {
            var testSeq = GetPermutations(string.Join("", Enumerable.Range(0, 10)));
            return Convert.ToInt64(testSeq.ElementAt((int)InputParam-1));
        }

        private IEnumerable<string> GetPermutations(string set)
        {
            if (set.Length > 1)
                return from ch in set
                       from permutation in GetPermutations(set.Remove(set.IndexOf(ch), 1))
                       select string.Format("{0}{1}", ch, permutation);

                return new [] { set };
        }
    }
}
