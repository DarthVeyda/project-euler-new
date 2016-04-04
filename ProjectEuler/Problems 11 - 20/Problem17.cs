using System;
namespace ProjectEuler
{
    internal class Problem17 : BaseProblem
    {
        /*
         * If the numbers 1 to 5 are written out in words: one, two, three, four, five, 
         * then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
         * If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, 
         * how many letters would be used?
         * NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 
         * 23 letters and 115 (one hundred and fifteen) contains 20 letters. 
         * The use of "and" when writing out numbers is in compliance with British usage.
         */

        public Problem17(int problemNumber, long count, string outputTemplate)
            : base(problemNumber, count, outputTemplate)
        {
        }

        protected override long Solve()
        {
            long letterCount = 0;
            for (long number = 1; number <= InputParam; number++)
            {
                string tmpStr = NumberToWords(number);
                Console.WriteLine(tmpStr);
                letterCount += tmpStr.Replace(" ","").Replace("-","").Length;
            }
            return letterCount;
        }


        //Shamelessly lifted from the SO: http://stackoverflow.com/questions/2729752/converting-numbers-in-to-words-c-sharp
        private string NumberToWords(long number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }


    }
}
