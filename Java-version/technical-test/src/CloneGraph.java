import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Queue;



public class CloneGraph {
    public Node cloneGraph (Node node)
    {
        Map<Node, Node> map = new HashMap<>();
        Queue<Node> queue= new LinkedList<>();

        map.put(node, new Node(node.val));
    }
}
