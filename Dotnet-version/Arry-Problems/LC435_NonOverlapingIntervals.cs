using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice.Arry_Problems
{
    public class LC435_NonOverlapingIntervals
    {
        public static int EraseOverlapingIntervals(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            int countRemove = 0;


            int length = intervals.Length;
            var nonOverlapArr = new List<int[]>();
            nonOverlapArr.Add(intervals[0]);

            int i = 1;
            while (i < length)
            {
                var lastNonOverlap = nonOverlapArr.Last();
                var currentIntervals=intervals[i];
                if (IsOverlap(lastNonOverlap, currentIntervals) &&  lastNonOverlap[1]>currentIntervals[1])
                {
                    countRemove+=1;
                    nonOverlapArr[^1]=currentIntervals;
                }
                if (IsOverlap(lastNonOverlap, currentIntervals) &&  lastNonOverlap[1]<=currentIntervals[1])
                {
                    countRemove++;
                }
                else
                {
                    nonOverlapArr.Add(currentIntervals);
                }

                i++;

            }
            return countRemove;
        }

        private static bool IsOverlap(int [] list1, int[] list2)
        {
            return list1[1]>list2[0];
        }
    }



}