using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class SortColor
    {
        public static void SortColors(int[] nums){
            int l=0, m=0, h=nums.Length-1;
            while (m<=h){
                if (nums[m]==0){
                    swap (nums, l, m);
                    l++;
                    m++;
                }else if (nums[m]==1) m++;
                else {
                    swap (nums, m, h);
                    h--;
                }
            }
        }

        private static void swap(int[]nums, int indexA, int indexB){
            int temp=nums[indexA];
            nums[indexA]=nums[indexB];
            nums[indexB]=temp;
        }
    }
}