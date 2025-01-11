using System.Text.Json;

namespace Matrix;

public class Newspaper
{
    public static char[,] minesweeper(int N, List<string> list)
    {
        var map = new char[10, 10];
        for (int j=0; j<10; j++)
        {
            for (int k=0; k<10;k++)
            {
                map[j,k] = '.';
            }
        }

        for (int i = 0; i < N; i++)
        {
            var cor = list[i].Split(",");
            int x = int.Parse(cor[0])-1;
            int y = int.Parse(cor[1])-1;

            map[x, y] = 'X';
        }

        // Console.WriteLine(JsonSerializer.Serialize(map));
        var jaggedArray = new string[map.GetLength(0)];
        for (int i = 0; i < map.GetLength(0); i++)
        {
            char[] row = new char[map.GetLength(1)];
            for (int j = 0; j < map.GetLength(1); j++)
            {
                row[j] = map[i, j];
            }
            jaggedArray[i] = new string(row);
        }

        // Serialize the jagged array
        string json = JsonSerializer.Serialize(jaggedArray);

        Console.WriteLine(json);
        for(int i = 0; i<10; i++)
        {
            for(int j=0; j<10; j++)
            {
                if (map[i, j] != 'X')
                {
                     var count = CountAdjacentBombs(map, i, j);
                    // map[i, j] = count.ToString()[0];
                }
                
            }
        }

        return map;


    }

    private static int CountAdjacentBombs(char[,] grid, int x, int y)
    {

        var directions = new int [][]{
        new int []{-1, -1}, 
        new int [] {-1, 0}, 
        new int [] {-1, 1},
        new int [] { 0, -1},         
        new int [] { 0, 1},
        new int [] { 1, -1},
        new int [] { 1, 0}, 
        new int [] { 1, 1}
    };

        int count = 0;
        int n = grid.GetLength(0); // Jumlah baris
        int m = grid.GetLength(1); // Jumlah kolom

        for (int i=0; i<n; i++)
        {
            // int dx=directions[i][0];
            // int dy=directions[i][1];
            // int nx=x+dx;
            // int ny=y+dy;

            // if(nx>=0 && nx<n && ny>=0 && ny<m && grid[nx,ny]=='x')
            // {
            //     count++;
            // }
        }

        return count;
    }


    

}