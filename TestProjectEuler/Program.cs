using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;
using NUnit;
using NUnit.Framework;
using ProjectEuler;

namespace TestProjectEuler
{
    internal class Program
    {
        private static void Main()
        {
            //GetFactorsPerf();            
            Console.Read();
        }
        private static void GetFactorsPerf()
        {
            Console.WriteLine("Testing GetFactors");
            long LargeNumber = 6789876543210000;
            List<long> Factors1;
            List<long> Factors2;
            List<double> Meth1Times = new List<double>();
            List<double> Meth2Times = new List<double>();
            for (int i = 0; i < 200; i++)
            {
                var timer = Stopwatch.StartNew();
                Factors1 = new List<long>(CommonFunctions.SmarterGetAllFactors(LargeNumber));
                timer.Stop();
                Meth1Times.Add(timer.Elapsed.TotalMilliseconds);

                timer.Restart();
                Factors2 = new List<long>(CommonFunctions.EvenSmarterGetAllFactors(LargeNumber));
                timer.Stop();
                Meth2Times.Add(timer.Elapsed.TotalMilliseconds);
            }
            Console.WriteLine("SmarterGetAllFactors average execution time: {0}",
                Meth1Times.Average(x => x));
            Console.WriteLine("EvenSmarterGetAllFactors average execution time: {0}",
                Meth2Times.Average(x => x));
        }
    }

    [TestFixture]
    public class GCDTests
    {
        [Test]
        public void HaveCommonDivisorsTest()
        {
            var num1 = 2 * 2 * 3 * 3 * 5 * 11;
            var num2 = 2 * 3 * 5 * 7 * 11 * 13;
            Assert.AreEqual(2 * 3 * 5 * 11, CommonFunctions.GCD(num1, num2));
        }

        [Test]
        public void FirstIsDivisorOfSecondTest()
        {
            var num1 = 2 * 2 * 3 * 3 * 5 * 11;
            var num2 = 3 * 5;
            Assert.AreEqual(num2, CommonFunctions.GCD(num1, num2));
        }

        [Test]
        public void NoCommonDivisorsTest()
        {
            var num1 = 2 * 2 * 3 * 3 * 5 * 11;
            var num2 = 7 * 13;
            Assert.AreEqual(1, CommonFunctions.GCD(num1, num2));
        }
    }

    [TestFixture]
    public class PrimesTest
    {
        [Test]
        public void Is1601Prime()
        {
            Assert.AreEqual(true,CommonFunctions.IsPrime(1601));
        }

        [Test]
        public void Is1Prime()
        {
            Assert.AreEqual(false, CommonFunctions.IsPrime(1));
        }
    }

    //[TestFixture]
    //public class AllIndexOfTest
    //{
    //    [Test]
    //    public void SeveralOccurencesTest()
    //    {
    //        Assert.AreEqual(new List<int> { 3, 5, 8 }, Problem26.AllIndexOf("32243439438221", "43"));
    //    }

    //    [Test]
    //    public void SingleOccurencesTest()
    //    {
    //        Assert.AreEqual(new List<int> { 9 }, Problem26.AllIndexOf("32243439438221", "382"));
    //    }

    //    [Test]
    //    public void NoOccurencesTest()
    //    {
    //        Assert.AreEqual(new List<int>(), Problem26.AllIndexOf("32243439438221", "7"));
    //    }
    //}

    [TestFixture]
    public class ShiftStringTest
    {
        [Test]
        public void ShiftNegativeTest()
        {
            Assert.AreEqual("xbrownfo", Utility.ShiftString("brownfox", -1));
        }

        [Test]
        public void ShiftZeroTest()
        {
            Assert.AreEqual("brownfox", Utility.ShiftString("brownfox", 0));
        }

        [Test]
        public void ShiftOneTest()
        {
            Assert.AreEqual("9090909090", Utility.ShiftString("0909090909", 1));
        }

        [Test]
        public void ShiftTooLongTest()
        {
            Assert.AreEqual("32", Utility.ShiftString("23", 3));
        }
    }

    [TestFixture]
    public class PadWithZeroesTest
    {
        [Test]
        public void PadLargerTest()
        {
            Assert.AreEqual("0001234", Utility.PadWithZeroes(new BigInteger(1234), 7));
        }

        [Test]
        public void PadEqualTest()
        {
            Assert.AreEqual("9999999", Utility.PadWithZeroes(new BigInteger(9999999), 7));
        }

        [Test]
        public void PadSmallerTest()
        {
            Assert.AreEqual("12345678987654321", Utility.PadWithZeroes(new BigInteger(12345678987654321), 7));
        }

        [Test]
        public void PadZeroTest()
        {
            Assert.AreEqual("0000", Utility.PadWithZeroes(new BigInteger(0), 4));
        }
    }
}
