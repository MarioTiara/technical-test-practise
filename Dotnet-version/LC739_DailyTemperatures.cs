using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class LC739_DailyTemperatures
    {
        public static int[] DailyTemperatures(int[] temperatures)
        {
            int length = temperatures.Length;
            int[] answer = new int[length];
            int l = 0;

            while (l < length)
            {
                int r = l + 1;
                var diff = 0;
                while (diff <= 0 && r < length)
                {
                    diff = temperatures[r] - temperatures[l];
                    r++;
                }

                if (diff > 0) answer[l] = r - l - 1;
                else answer[l] = 0;
                l++;
            }

            return answer;
        }
    }
}