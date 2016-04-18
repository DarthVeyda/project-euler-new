using System.Numerics;

namespace ProjectEuler
{
    internal class Utility
    {
        public static string PadWithZeroes(BigInteger number, int length)
        {
            var numStr = number.ToString();
            if (length < numStr.Length) return numStr;
            return number.ToString().PadLeft(length, '0');
        }

        public static string ShiftString(string str, int positions)
        {
            var length = str.Length;
            if (positions < 0) positions = length + positions;
            if (length < positions)
            {
                do
                {
                    positions -= length;
                } while (length < positions);
            }
            return str.Substring(positions, length - positions) + str.Substring(0, positions);
        }
    }
}