namespace Technical_Test_Practice.Trees;

public class TreeNode
{

    public int val;
    public TreeNode? right;
    public TreeNode? left;
    public TreeNode(int val, TreeNode? right = null, TreeNode? left = null)
    {
        this.val = val;
        this.right = right;
        this.left = left;
    }
}

