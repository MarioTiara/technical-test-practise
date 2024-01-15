
namespace Technical_Test_Practice
{
    public class MaximumProductSubArray
    {
        public static int MaxProduct(int[] nums){
            if (nums.Length<=0) return 0;
            int maxSub=int.MinValue;
            for (int i=0; i<nums.Length; i++){
                 int currentProd= nums[i];
                 int r=i+1;
                 while (r<nums.Length &&currentProd*nums[r]>0){
                    currentProd*=nums[r];
                    r++;
                 }
                maxSub=Math.Max (currentProd, maxSub);

            }

            return maxSub;
        }        
    }
}