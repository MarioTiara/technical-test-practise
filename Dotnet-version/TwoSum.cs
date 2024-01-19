
namespace Technical_Test_Practice
{
    public class TwoSum
    {
        public static int[] twoSum(int[] nums, int target)
        {
            var pairsMap = new Dictionary<int, int[]>();
            
            for (int i = 0; i <= nums.Length; i++)
            {
                var substract = target - nums[i];
                if (!pairsMap.ContainsKey(substract) && !pairsMap.ContainsKey(nums[i]))
                {
                    pairsMap.Add(nums[i], new int[] { substract, i });
                }
                else if (pairsMap.ContainsKey(substract) && pairsMap[substract][0]==nums[i]){
                    return new int[] { pairsMap[substract][1], i};
                }
            }

            return new int[2];
        }
    }
}