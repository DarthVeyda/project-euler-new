using System.Linq;
using System.Text;

namespace ProjectEuler
{
    /*
     * A palindromic number reads the same both ways. 
     * The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
     * Find the largest palindrome made from the product of two 3-digit numbers.
     */

    internal class Problem4 : BaseProblem
    {
        public Problem4(int problemNumber, long inputParam, string outputTemplate)
            : base(problemNumber, inputParam, outputTemplate)
        {
        }

        protected override long Solve()
        {
            long maxProduct = 0;
            var palindromeProducts = Enumerable.Empty<object>()
             .Select(r => new { Num1 = (int)maxProduct, Num2 = (int)maxProduct, Product = maxProduct }) // prototype of anonymous type
             .ToList();
            for (int number1 = 999; number1 >= 111; number1--) 
            {
                for (int number2 = 999; number2 >= 111; number2--) 
                {
                    long product = number1 * number2;
                    string sProduct = product.ToString();
                    if (product >= 100001)
                    {
                        if ((sProduct[0] == sProduct[5]) && (sProduct[1] == sProduct[4]) && (sProduct[2] == sProduct[3]))
                        {
                            palindromeProducts.Add(new { Num1 = number1, Num2 = number2, Product = product });
                        }
                    }
                    else 
                    {
                        break;                       
                    }
                }
            }

            var m = palindromeProducts.OrderByDescending(i => i.Product).FirstOrDefault();
            //not the best way to handle custom output, but I'm out of ideas for now
            StringBuilder tmp = new StringBuilder();
            OutputTemplate = tmp.AppendFormat(OutputTemplate, m.Num1, m.Num2, m.Product).ToString();
            return m.Product;
        }
    }
}
