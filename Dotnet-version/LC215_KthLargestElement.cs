using System.Collections.Concurrent;

namespace Technical_Test_Practice.LeetCode;


public class KathLargestElement
{
    public static int FindKthLargest(int[] nums, int k)
    {
        //
         k= nums.Length - k; 
         return QucikSelect(nums, 0, nums.Length - 1, k);
    }

    private static int QucikSelect(int[] nums, int left, int right, int k)
    {
        int pivot = nums[right];
        int pivotIdx = left;
        for (int i = left; i < right; i++)
        {
            if (nums[i] <= pivot)
            {
                Swap(nums, i, pivotIdx);
                pivotIdx++;
            }
        }

        Swap(nums, pivotIdx, right);
        
        if (pivotIdx > k) return QucikSelect(nums, left, pivotIdx - 1, k);
        if (pivotIdx < k) return QucikSelect(nums, pivotIdx + 1, right, k);
        return nums[pivotIdx];
    }

    

    public static void Swap (int[] nums, int idxA, int idxB)
    {
        int temp = nums[idxA];
        nums[idxA] = nums[idxB];
        nums[idxB] = temp;
    }
}