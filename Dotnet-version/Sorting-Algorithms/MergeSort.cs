using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice.Sorting_Algorithms
{
    public class MergeSort
    {
        public static void MergeSortAlgorithm(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                // Recursively sort the first and second halves
                MergeSortAlgorithm(array, left, mid);
                MergeSortAlgorithm(array, mid + 1, right);

                // Merge the sorted halves
                Merge(array, left, mid, right);
            }
        }

        static void Merge(int[] array, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            // Create temporary arrays
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            // Copy data to temporary arrays leftArray[] and rightArray[]
            Array.Copy(array, left, leftArray, 0, n1);
            Array.Copy(array, mid + 1, rightArray, 0, n2);

            

            // Merge the temporary arrays back into array[left..right]
            int i = 0, j = 0, k = left;
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            // Copy the remaining elements of leftArray[], if there are any
            while (i < n1)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }

            // Copy the remaining elements of rightArray[], if there are any
            while (j < n2)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
        }

        static void PrintArray(int[] array)
        {
            foreach (var element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }


}
