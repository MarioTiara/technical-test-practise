using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class MaximumSubArray
    {
        public static int maxSubArray(int[] nums)
        {
            int n = nums.Length;
            int maxSum = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int currSum=0;
                for (int j=i; j<n; j++){
                    currSum += nums[j];
                    if (currSum>maxSum) maxSum=currSum;
                }
            }

            return maxSum;
        }

        public static int EfficentMaxSubArray(int[] nums)
        {
            int curSum=0;
            int maxSum= int.MinValue;

            foreach (var num in nums){
                curSum+=num;
                if (curSum>maxSum) maxSum=curSum;
                if (curSum<0) curSum=0;
            }

            return maxSum;
        }
    }
}