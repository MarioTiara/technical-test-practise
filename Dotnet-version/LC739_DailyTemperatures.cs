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
            Stack<int> stack= new Stack<int>();

            for (int i=0; i<length; i++)
            {
                while (stack.Count> 0 && temperatures[i]> temperatures[stack.Peek()]){
                    int prevIndex = stack.Pop();
                    answer[prevIndex]= i-prevIndex;

                }

                stack.Push(i);
            }

            return answer;

        }
    }
}