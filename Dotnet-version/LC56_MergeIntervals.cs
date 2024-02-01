using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class LC56_MergeIntervals
    {
        public static int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return Array.Empty<int[]>();

            var length = intervals.Length - 1;
            // Sort intervals based on their start times
            QuickSort(intervals, 0, length);

            //init merged array
            List<int[]> mergedArr = new();
            mergedArr.Add(intervals[0]);

            for (int i = 1; i <=length; i++)
            {
                var lastElement = mergedArr.Last();
                if (intervals[i][0] <= lastElement[1])
                {
                    lastElement[1] = Math.Max(lastElement[1], intervals[i][1]);
                }

                else
                {
                    mergedArr.Add(intervals[i]);
                }
            }

            return mergedArr.ToArray();

        }

        private static void QuickSort(int[][] intervals, int start, int end)
        {
            if (start < end)
            {
                var pIndex = Partition(intervals, start, end);
                QuickSort(intervals, start, pIndex - 1);
                QuickSort(intervals, pIndex + 1, end);
            }

        }

        private static int Partition(int[][] intervals, int start, int end)
        {
            int pivot = end;
            int pIndex = start;
            for (int i = start; i < end; i++)
            {
                if (intervals[i][0] <= intervals[pivot][0])
                {
                    swap(intervals, i, pIndex);
                    pIndex += 1;
                }
            }

            swap(intervals, pivot, pIndex);
            return pIndex;
        }

        private static void swap(int[][] intervals, int a, int b)
        {
            var temp = intervals[a];
            intervals[a] = intervals[b];
            intervals[b] = temp;
        }
    }
}