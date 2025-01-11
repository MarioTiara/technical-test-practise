namespace HackerRank;

public class GridChallange
{
    public static string gridChallenge(List<string> grid)
    {
        int cLength = grid[0].Length;
        for (int i = 0; i < cLength; i++)
        {
            int last = 0;
            for (int j = 0; j < grid.Count; j++)
            {
                Console.WriteLine((char)grid[j][i]);
                int cur = (int)grid[j][i];
                Console.WriteLine(cur);
                if (last > cur)
                {
                    return "NO";
                }
                last = cur;
            }

        }
        return "YES";
    }

}