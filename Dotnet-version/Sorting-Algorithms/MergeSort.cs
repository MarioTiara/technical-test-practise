using System.Text.Json;

namespace SortingAlgorithms;

public class MergeSort
{
    public static void Sort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            Sort(arr, left, mid);
            Sort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    private static void Merge(int[] arr, int left, int mid, int right)
    {
        //make left and right array
        var leftArr = new int[mid - left + 1];
        var rightArr = new int[right - mid];
        for (int i = 0; i < leftArr.Length; i++)
        {
            leftArr[i] = arr[left + i];
        }
        for (int i = 0; i < rightArr.Length; i++)
        {
            rightArr[i] = arr[mid + i + 1];
        }

        //merge left and right array
        int lPointer = 0, rPoint = 0;
        int k = left;
        while (lPointer < leftArr.Length && rPoint < rightArr.Length)
        {
            if (leftArr[lPointer] < rightArr[rPoint])
            {
                arr[k] = leftArr[lPointer];
                lPointer++;
            }
            else
            {
                arr[k] = rightArr[rPoint];
                rPoint++;
            }
            k++;
        }

        //copy remaining element
        while (lPointer < leftArr.Length)
        {
            arr[k] = leftArr[lPointer];
            lPointer++;
            k++;
        }

        while (rPoint < rightArr.Length)
        {
            arr[k] = rightArr[rPoint];
            rPoint++;
            k++;
        }
    }
}