using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice.Arry_Problems
{
    public class LC1944_Number_of_Visible_People_n_Queue
    {
        public static int[] CanSeePersonsCount(int[] heights)
        {
            int n = heights.Length;
            var result = new int[n];
            var stack = new Stack<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                int count = 0;
                while (stack.Count > 0 && stack.Peek() < heights[i])
                {
                    stack.Pop();
                    count++;
                }
                if (stack.Count > 0)
                {
                    count++;
                }
                result[i] = count;
                stack.Push(heights[i]);
            }

            return result;
        }
    }
}