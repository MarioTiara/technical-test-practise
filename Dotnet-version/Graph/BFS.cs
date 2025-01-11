namespace Technical_Test_Practice;

public class BFS
{
    public static void TraverseMatrix (int [,] matrix, int startNode=0)
    {
        int n= matrix.GetLength(0);
        bool[] visited= new bool[n];
        Queue<int> q= new Queue<int>();
        q.Enqueue(startNode);
        visited[startNode] = true;

        while (q.Count > 0)
        {
            var v= q.Dequeue();
            Console.WriteLine(v+" ");
            for (int i=1; i<n; i++)
            {
                if (matrix[v,i]==1 && !visited[i])
                {
                    visited[i]= true;
                    q.Enqueue(i);
                }
            }
        }
    }

    public static void TraverseMatrix (int [][] matrix)
    {
        int startNode=0;
        int n= matrix.Length;
        Queue<int> queue = new Queue<int>();
        HashSet<int> visited = new HashSet<int>();
        queue.Enqueue(startNode);
        visited.Add(startNode);

        Console.WriteLine("BFS Traversal");
        while (queue.Count > 0)
        {
            int currentNode=queue.Dequeue();
            Console.Write(currentNode+" ");

            for (int neighbours=0; neighbours<n; neighbours++)
            {
                if (matrix[currentNode][neighbours] == 1 && !visited.Contains(neighbours))
                {
                    queue.Enqueue(currentNode);
                    visited.Add(currentNode);
                }
            }
        }

        Console.WriteLine();
    }
}