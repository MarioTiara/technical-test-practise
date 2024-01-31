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

            List<int[]> result = new();
            result.Add(intervals[0]);
            int length = intervals.Length;

            if (intervals.Length < 1){
                result.ToArray();
            }

            for (int i = 1; i < length; i++)
            {
                var currentIntervals = intervals[i];
                var prevIntervals = result.Last();
                if (currentIntervals[0] <= prevIntervals[1])
                {
                    result[i-1][1]=currentIntervals[1];
                }
                else
                {
                    result.Add(currentIntervals);
                }
            }
            return result.ToArray();

        }
    }
}