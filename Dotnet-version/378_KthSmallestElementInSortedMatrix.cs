namespace Technical_Test_Practice.LeetCode;

public class LC215_KthLargestElement
{
    public int FindKthLargest(int[][] nums, int k)
    {
        // Sort the array in descending order
        var temp= new int[nums.Length*nums[0].Length];

        var index = 0;
        foreach (var num in nums)
        {
            foreach (var n in num)
            {
                temp[index] = n;
                index++;
            }
        }

        Array.Sort(temp);
        return temp[k - 1];
    }
}