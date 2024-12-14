namespace Technical_Test_Practice;

public class BinarySearch
{
    public static int Seach (int[] nums, int target){
        int low=0;
        int height = nums.Length-1;

        while (low<=height){
            int mid = low+(height-low)/2;
            if (nums[mid]==target) return mid;

            if (nums[mid]<target){
                low=mid+1;
                //artinya target ada di sebelah kiti mid
            }
            else{
                height=mid-1;
                //artinya target ada di sebelah kanan mid
            }
        }

        return -1;
    }
}