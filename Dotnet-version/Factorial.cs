using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class Factorial
    {
        public  static int Count (int n){
            int result=n;
            int curNum=n-1;
            while(curNum>=1){
                result=result*curNum;
                curNum--;
            }

            return result;
        }

        public static int FactRecursive(int x){
            if (x<=1) return x;
            return x * FactRecursive(x-1);
        }
    }
}