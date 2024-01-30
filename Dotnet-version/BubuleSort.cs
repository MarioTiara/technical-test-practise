using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class BubuleSort
    {
        public static void Sort(int[] array)
        {
            bool isSort=false;
            while (!isSort){
                isSort=true;

                for (int i=1; i<array.Length; i++){
                    if (array[i]<array[i-1]){
                        isSort=false;
                        swap (array, i, i-1);
                    }
                }
            }
        }

        private static void swap(int[] arr, int a, int b){
            var temp=arr[a];
            arr[a]=arr[b];
            arr[b]=temp;
        }
    }
}