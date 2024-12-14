using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice.Arry_Problems
{
    public class LC739_DailyTemperature
    {
        public static int[] DailyTemperatures(int[] temperatures) {
        var arrLength= temperatures.Length;
        var dailyTem= new int [arrLength];

        for (int i=0; i<arrLength; i++){
            var r=i;
            while(r<arrLength){
                if (temperatures[r]>temperatures[i]){
                    dailyTem[i]=r-i;
                    break;
                }
                r++;
            }
        }

        return dailyTem;
    }
    }
}