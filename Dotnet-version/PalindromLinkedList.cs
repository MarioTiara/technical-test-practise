
namespace Technical_Test_Practice
{
    public class ListNode {
        public int val;
        public ListNode? next;
        public ListNode (int val=0, ListNode? next= null)
        {
            this.val=val;
            this.next= next;
        }
    }
    public class PalindromLinkedList
    {
        public static bool IsPalindrome(ListNode? head)
        {
            List<int> nums = new ();
            while (head != null){
                nums.Add (head.val);
                head= head.next;
            }

            int l=0;
            int r=nums.Count-1;
            while (l<=r){
                
                if (nums[l]!=nums[r]) return false;
                l++;
                r--;
            }

            return true;
        }
    }
}