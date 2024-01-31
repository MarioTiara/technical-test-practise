

using System.Collections.Concurrent;

namespace Technical_Test_Practice.Sorting_Algorithms
{
    public class QuickSort
    {
        public static void SortQuick(int[] A, int start, int end)
        {
            if (start < end)
            {
                var pIndex = Partition(A, start, end);
                SortQuick(A, start, pIndex - 1);
                SortQuick(A, pIndex + 1, end);

            }
        }

        private static int Partition(int[] A, int start, int end)
        {
            var Pivot = end;
            var pIndex = start;
            for (int i = start; i < end; i++)
            {
                if (A[i] <= A[Pivot])
                {
                    Swap(A, i, pIndex);
                    pIndex += 1;
                }
            }

            Swap(A, pIndex, Pivot);
            return pIndex;

        }

        private static void Swap(int[] A, int i, int j)
        {
            var temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }
    }
}