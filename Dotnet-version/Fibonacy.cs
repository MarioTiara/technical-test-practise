using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class Fibonacy
    {
        //1,1,2,3,5,8,13,21.....
        //f(n)=f(n-1)+f(n-2)

        public static void Print (int n){
            int fn ,fn1,fn2;

            fn1=1;
            fn2=0;
            fn=fn1+fn2;
            Console.WriteLine(fn);
            for (int i=1; i<n; i++){
                fn=fn1+fn2;
                fn2=fn1;
                fn1=fn;
                Console.WriteLine(fn);
            }
        }
    }
}