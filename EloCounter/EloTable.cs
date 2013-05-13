using System;
using System.Collections.Generic;
using System.Text;

namespace EloCounter
{
    public class EloTable
    {
        static List<int> diffTable = new List<int>
            { 3,   10,  17,  25,  32,  39,  46,  53,  61,  68,  76,  83,  91,  98,  106, 113, 121,
              129, 137, 145, 153, 162, 170, 179, 188, 197, 206, 215, 225, 235, 245, 256, 267, 278,
              290, 302, 315, 328, 344, 357, 374, 391, 411, 432, 456, 484, 517, 559, 619, 735};

        public static int DivideRound(int num, int denum)
        {
            int sign = 1;
            if (num < 0)
            {
                sign = -1;
            }

            return ((num * 10) / denum + 5 * sign) / 10;
        }

        public static int GetExpectedPercent(int avgRate, int playerRate)
        {
            int diff = playerRate - avgRate;
            int sign = 1;
            if (diff < 0)
            {
                sign = -1;
                diff = -diff;
            }

            int index = diffTable.BinarySearch(diff);
            if (index < 0)
            {
                index = ~index;
            }

            return 50 + index * sign;
        }

        public static int GetNewRate(int oldRate, int sumRate, int denom, int maxPoints, int points)
        {
            int avgRate = DivideRound(sumRate, denom);
            return GetNewRate(oldRate, avgRate, maxPoints, points);
        }

        public static int GetNewRate(int oldRate, int avgRate, int maxPoints, int points)
        {
            int expPercent = GetExpectedPercent(avgRate, oldRate);
            int expPoints = DivideRound(expPercent * maxPoints / 2, 10); //expected points x 10

            return oldRate + DivideRound(15 * (points * 5 - expPoints), 10);
            // -DivideRound(15 * (points * 100 - expPercent * maxPoints), 200);
        }
    }
}
