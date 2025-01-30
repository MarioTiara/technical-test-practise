class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val=val
        self.left=left
        self.right= right
        

def create_binary_tree(values):
    if not values:
        return None
    
    root = TreeNode(values[0])
    queue = [root]
    i = 1
    
    while i < len(values):
        current = queue.pop(0)
        
        if values[i] is not None:
            current.left = TreeNode(values[i])
            queue.append(current.left)
        i += 1
        
        if i < len(values) and values[i] is not None:
            current.right = TreeNode(values[i])
            queue.append(current.right)
        i += 1
    
    return root


class BinarySearchTree:
    def __init__(self):
        self.root=None
    
    def insert(self,value:int):
        self.root=self.__insert_node(self.root, value)
        
    def __insert_node(self, node:TreeNode, value:int)->TreeNode:
        if not node :
            return TreeNode(val=value)
        if value<node.val:
            node.left=self.__insert_node(node.left, value)
        elif value >node.val:
            node.right=self.__insert_node(node.right, value)
        
        return node
    




