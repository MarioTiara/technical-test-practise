from collections import deque
from typing import Optional
from  binary_tree import *

#   3
# /   \
#2     5
#/      / \
#1      4  6

#

def inorder_traversal(node:TreeNode):    #Out: 123456
    if not node: return
    
    inorder_traversal(node.left)
    print(node.val)
    inorder_traversal(node.right)

def preorder_traversal(node:TreeNode):
    if not node: return
    
    print(node.val)
    preorder_traversal(node.left)
    preorder_traversal(node.right)

def postorder_traversal(node:TreeNode):
    if not node: return
    
    postorder_traversal(node.right) 
    postorder_traversal(node.left)
    print(node.val) 


def bfs (node:TreeNode):
    if not node:
        print ("Empty")
        return
    res=[]
    que = deque()
    que.append(node)
    while que:
        current= que.popleft()
        res.append(current.val)
        if current.left:
            que.append(current.left)
        if current.right:
            que.append(current.right)

    return res

def leafSimilar(root1: Optional[TreeNode], root2: Optional[TreeNode]) -> bool:
    def dfs(root: TreeNode, leaf:list):
        if not root:
            return
        if not root.left and not root.right:
            leaf.append(root.val)
        
        dfs(root.left, leaf)
        dfs(root.right, leaf)
            
    
    leaf1=[]
    leaf2=[]
    dfs(root1, leaf1)
    dfs(root2, leaf2)
    
    return leaf1==leaf2

def goodNodes(root: TreeNode) -> int:
    def dfs(root:TreeNode, max_good:int, good:list):
        if not root:
            return
        
        if root.val >= max_good:
            good.append(root.val)
            max_good=root.val
        
        dfs(root.left, max_good, good)
        dfs(root.right, max_good, good)
        
    result=[]
    
    dfs(root, root.val, result)
    return len(result)
        
# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def pathSum(self, root: Optional[TreeNode], targetSum: int) -> int:
        if not root:
            return 0
        
        def dfs (node, current_sum):
            if not node:
                return 0
            
            current_sum+=node.val
            count=0
            if current_sum==targetSum:
                count=1
            
            return count+ dfs(node.right, current_sum)+dfs (node.left, current_sum)
        
        return dfs(root,0)+self.pathSum(root.left, targetSum)+self.pathSum(root.right, targetSum)
    

def count_path(root:TreeNode):
    count=0
    def dfs (node:TreeNode, last_dir:str):
        nonlocal count
        if not node:
            return 0
        
        if last_dir=="right" and node.left is not None:
            count+=1
        
        if last_dir=="left" and node.right is not None:
            count+=1
        
        return count+dfs(node.right, "right")+ dfs(node.left, "left")
       
        
    
    dfs (root, "root")  
    return count

vals=[1,None,1,1,1,None,None,1,1,None,1,None,None,None,1]
root= create_binary_tree(vals)


result= count_path(root)
print (result)


