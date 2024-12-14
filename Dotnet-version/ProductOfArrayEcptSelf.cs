

namespace Technical_Test_Practice
{
    public class ProductOfArrayEcptSelf
    {
        public  static int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int[] result = new int[n];
        
        // Calculate prefix products
        int prefixProduct = 1;
        for (int i = 0; i < n; i++) {
            result[i] = prefixProduct;
            prefixProduct *= nums[i];
        }
        
        // Calculate suffix products and combine with prefix products
        int suffixProduct = 1;
        for (int i = n - 1; i >= 0; i--) {
            result[i] *= suffixProduct;
            suffixProduct *= nums[i];
        }
        
        return result;
    }
    }
}