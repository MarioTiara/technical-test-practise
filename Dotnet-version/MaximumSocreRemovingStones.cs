using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class MaximumSocreRemovingStones
    {
        /*

        MaximumProductSubArray Socre from removing Stones

          You are playing a solitaire game with three piles of stones of sizes a,b, and c respectively. 
          Each turn you choose two different nont-empty piles, take  one stones from each, and add 1 point
          to your score. The game stops when there are fewer than two non-empty piles 
          (meaning there are no more availiable moves).

          Given three integers a, b, and c, return the maximum score you can get.

          Example:
          Input: a=2, b=4, c=6;
          Output:6

          Explain:
          Example 1:  Input:a-2,b=4.c=6  Output  Explanation: The starting state is (2, 4, 6). One optimal set of  moves is;  
          - Take from 1st and 3rd piles, state is now (1, 4 ,5 ) 
          - Take from 1st and 3rd piles, state is now (0, 4 ,4)
           - Take from 2nd and 3rd piles, state is now  (0,3,4)
           - Take from 2nd and 3rd piles, state is now (0, 2,2) 
           - Take from 2nd and 3rd piles, state is now (0, 1,1)  
           - Take from 2nd and 3rd piles, state is now (0, 0, 0)
           There are fewer than two non- empty piles, so the game ends 
         */


        public static int Solution(int a, int b, int c)
        {
            var inputArray = new List<int> { a, b, c };
            var idealArr = inputArray.Where(p => p > 0).Order().ToArray();
            var result = 0;
            while (idealArr.Sum() > 0)
            {
                idealArr[0]--;
                idealArr[idealArr.Length - 1]--;
                idealArr = idealArr.Where(p => p > 0).Order().ToArray();

                result++;
            }

            return result;
        }
    }
}