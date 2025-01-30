from typing import Optional


class ListNode:
    def __init__(self, val=0, next=None):
        self.val=val
        self.next= next

def printLinkedList(head:ListNode):
    curr=head
    while curr:
        print (curr.val)
        curr= curr.next

node1 = ListNode(1)
node2 = ListNode(2)
node4 = ListNode(4)
node5 = ListNode(5)
node5.next=node4
node4.next=node2
node2.next=node1

head=node5

slow=head
fast=head
prev=None
while fast and fast.next:
    prev=slow
    slow=slow.next
    fast= fast.next.next


left_half=head
right_half=prev.next

prev.next=None


prev=None
curr=right_half

while curr:
    next_node=curr.next
    curr.next= prev
    prev=curr
    curr=next_node



l=left_half
r=prev

max_sum=0

while l and r:
    sm=l.val+r.val
    max_sum=max(max_sum, sm)
    l=l.next
    r=r.next    
    

print (max_sum)


    
    
