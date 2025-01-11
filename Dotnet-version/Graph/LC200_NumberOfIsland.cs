using System.Text.Json;

namespace Technical_Test_Practice;

public class NumberOfIsland
{

    public  static int NumsIsLands(char[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int[][] directions = new int[][] {
            new int [] { 0, 1,},
            new int [] { 0, -1,},
            new int [] { 1, 0,},
            new int [] { -1, 0,},

        };
        bool[,] visited = new bool[rows, cols];

        void dfs (int startX, int startY)
        {
            if (startX<0 || startY<0 || startX>rows || startY>cols || visited[startX, startY] || grid[startX][startY]=='0')
            {
                return;
            }

            visited[startX, startY] = true;
            grid[startX][startY]='0';
            foreach (var di in directions)
            {
                dfs(startX+di[0], startY+di[1]);
            }
        }
        void BFS(int startX, int startY)
        {
            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((startX, startY));
            visited[startX, startY] = true;
            grid[startX][startY]='0';

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();
                foreach (var dir in directions)
                {
                    int newX = x + dir[0], newY = y + dir[1];
                    if (newX >= 0 && newY >= 0 && newX < rows && newY < cols && grid[newX][newY] == '1' && !visited[newX, newY])
                    {
                        visited[newX, newY] = true;
                        grid[newX][newY] = '1';
                        queue.Enqueue((newX, newY));
                    }
                }
            }

        }


        int NumberOfIsland = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == '1' && !visited[i, j])
                {
                    //BFS(i, j);
                    dfs(i,j);
                    Console.WriteLine(JsonSerializer.Serialize(grid));
                    NumberOfIsland++;
                }
            }
        }

        return NumberOfIsland;


    }
}