


public class MergeTwoSortedList {
    public static ListNode mergeTwoLists(ListNode list1, ListNode list2){
        var dummy = new ListNode(0);
        var currentNode = dummy;

        while (list1!= null && list2 != null){
            if (list1.val < list2.val){
                currentNode.next=list1;
                list1=list1.next;
            }else {
                currentNode.next=list2;
                list2=list2.next;
            }

            currentNode=currentNode.next;
        }

        if (list1!= null){
            currentNode.next=list1.next;
        }else  if (list2!=null) currentNode.next=list2.next;

        return  dummy.next;
    }
}


