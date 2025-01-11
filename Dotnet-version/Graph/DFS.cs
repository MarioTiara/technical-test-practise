using System.Security.Cryptography.X509Certificates;

namespace Technical_Test_Practice;

public class GraphTraverse
{
    public static void DFS(int[,] matrix, int start)
    {
        bool[] visited = new bool[matrix.GetLength(0)];
        int vertices = matrix.GetLength(0);

        void dfs(int start)
        {
            visited[start] = true;
            Console.WriteLine($"visited node: {start}");

            for (int i = 0; i < vertices; i++)
            {
                if (matrix[start, i] == 1 && !visited[i])
                {
                    dfs(i);
                }
            }
        }
        dfs(start);
    }

    public static void DFS(int[,] grid, int startX, int startY)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        bool[,] visited = new bool[rows, cols];

        void dfs(int startX, int startY)
        {
            if (startX < 0 || startY < 0 || startX > rows || startY > cols || visited[startX, startY] || grid[startX, startY] == 0)
            {
                return;
            }

            visited[startX, startY] = true;
            Console.WriteLine($"visited cell: ({startX}, {startY})");

            int [][] directions= new int [4][]
            {
                new int[]{0,1},
                new int[]{0,1},
                new int[]{0,1},
                new int[]{0,1},
            };

            foreach(var dir in directions)
            {
                int newX=startX+dir[0];
                int newY=startY+dir[1];

                dfs(newX, newY);
            }
        }

        dfs(startX, startY);

    }
}