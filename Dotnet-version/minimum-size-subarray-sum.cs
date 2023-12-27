
namespace Technical_Test_Practice
{
    public class minimumSizeSubarraySum
    {
        public static int MinSubArrayLen(int target, int[] nums)
        {
            int r_pointer;
            int l_pointer = 0;
            int minLen = int.MaxValue;
            int sum = 0;

            for (r_pointer = 0; r_pointer < nums.Length; r_pointer++)
            {
                sum += nums[r_pointer];
                while (sum >= target)
                {
                    minLen = Math.Min(r_pointer-l_pointer+1, minLen);
                    sum-=nums[l_pointer];
                    l_pointer++;
                }
            }

            return minLen==int.MaxValue?0:minLen;

        }
    }
}