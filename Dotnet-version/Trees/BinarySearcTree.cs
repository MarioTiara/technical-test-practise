namespace Technical_Test_Practice.Trees;

public class BinarySearchTree
{
    public TreeNode? Root;

    public void Insert(int value)
    {
        Root = InsertNode(Root, value);
    }
    public bool Search(int value, TreeNode? root = null)
    {
        root ??= Root;

        if (root == null)
            return false;

        if (root.val == value)
            return true;
            
        if (root.val < value)
            return Search(value, root.right);
        else return Search(value, root.left);

    }


    private TreeNode? InsertNode(TreeNode? node, int value)
    {
        if (node == null)
        {
            return new TreeNode(value);
        }

        if (node.val < value)
        {
            node.right = InsertNode(node.right, value);
        }
        else if (node.val > value)
        {
            node.left = InsertNode(node.left, value);
        }

        return node;
    }

    public void BFS()
    {
        if (Root==null)
        {
            Console.WriteLine("Tree is empty");
            return;
        }

        Queue<TreeNode> queue= new Queue<TreeNode>();
        queue.Enqueue(Root);

        while(queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            Console.Write(node.val+" ");

            if (node.left != null)
            {
                queue.Enqueue(node.left);
            }

            if (node.right != null)
            {
                queue.Enqueue(node.right);
            }
        }
    }

     public void BFSLevel()
    {
        if (Root==null)
        {
            Console.WriteLine("Tree is empty");
            return;
        }

        IList<IList<int>> result= new List<IList<int>>();

        Queue<(TreeNode, int)> queue= new Queue<(TreeNode, int)>();
        queue.Enqueue((Root,0));
        var curretLevel=0;

        while(queue.Count > 0)
        {
            var (node, level) = queue.Dequeue();
            if (level!=curretLevel)
            {
                Console.WriteLine();
                curretLevel=level;
                result.Add(new List<int>());
            }

            Console.Write(node.val+" ");
            result.Last().Add(node.val);
            if (node.left != null)
            {
                queue.Enqueue((node.left, level+1));
            }

            if (node.right != null)
            {
                queue.Enqueue((node.right, level+1));
            }
        }
    }
}