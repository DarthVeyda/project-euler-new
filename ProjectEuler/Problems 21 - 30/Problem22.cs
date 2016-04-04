using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    internal class Problem22 : BaseProblem
    {
        /*
         * Using names.txt, a 46K text file containing over five-thousand first names, 
         * begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, 
         * multiply this value by its alphabetical position in the list to obtain a name score.
         * 
         * For example, when the list is sorted into alphabetical order, 
         * COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. 
         * 
         * So, COLIN would obtain a score of 938 × 53 = 49714.
         * 
         * What is the total of all the name scores in the file?
         */

        public Problem22(int problemNumber, long inputParam, string outputTemplate)
            : base(problemNumber, inputParam, outputTemplate)
        {
        }

        protected override long Solve()
        {
            var names = new SortedSet<string>();

            using (StreamReader reader = new StreamReader(@"..\..\Problems 21 - 30\p022_names.txt"))
            {
                while (!reader.EndOfStream)
                {
                    foreach (var s in reader.ReadLine().Split(','))
                    {
                        names.Add(s.Replace("\"",""));
                    }
                }
            }

            int index = 0;

            return names.Aggregate<string, long>(0,
                (current, name) => current + ++index*Encoding.ASCII.GetBytes(name).Sum(x => x - 65 + 1));
        }
    }
}
