using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class MergeSortedArray
    {
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0) return;

            int pointer1 = 0, pointer2 = 0;
            while (pointer1 < m && pointer2 < n)
            {
                if (nums1[pointer1] > nums2[pointer2] && nums1[pointer1] != 0)
                {
                    var temp = nums2[pointer2];
                    nums2[pointer2] = nums1[pointer1];
                    nums1[pointer1] = temp;

                    pointer1 += 1;
                    pointer2 += 1;
                }
                else {
                    pointer1++;
                }
            }

            for (int j = 0; j < n; j++)
            {
                nums1[m] = nums2[j];
                m++;
            }



        }
    }
}