using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class MergedTwoSortedList
    {
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        var merged= new ListNode(-1);
        var current= merged;
        while (list1!= null && list2!=null){
            if (list1.val< list2.val){
                current.next=list1;
                list1=list1.next;
            }else {
                current.next= list2;
                list2= list2.next;
            }
            
            current=current.next;

            
        }

        if (list1!= null) current.next=list1;
        if (list2!= null) current.next=list2;

        return merged.next;
    }
    }


}