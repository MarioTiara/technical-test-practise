namespace Technical_Test_Practice;

public class LC33_SearchInRotatedArray
{
    public static  int Search(int[] nums, int target)
    {
        int low=0;
        int hight=nums.Length-1;

        while(low<=hight){
            int mid= low+(hight-low)/2;
            if (nums[mid]==target) return mid;
            if (nums[mid]>nums[hight]){
                low=mid+1;
            }
            else{
                hight=mid;
            }
        }

        return -1;
    }
}