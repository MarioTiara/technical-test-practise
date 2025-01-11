namespace Technical_Test_Practice;

public class OrangeRotting
{
    public static int Result (int [][] grid)
    {
        int rows=grid.Length;
        int cols=grid[0].Length;

        Queue<(int,int)> queue = new Queue<(int, int)> ();
        int freshCount=0;

        for (int i=0; i<rows; i++)
        {
            for (int j=0; j<cols; j++)
            {
                if (grid[i][j] == 2)
                {
                    queue.Enqueue((i,j));
                }else if (grid[i][j]==1)
                {
                    freshCount++;
                }
            }
        }

        if (freshCount==0)
        {
            return -1;
        }

        int minutes=1;
        int [][] directions= new int [][]
        {
            new int []{0,1}, //right
            new int []{0,-1}, //left
            new int []{1,0}, //down
            new int []{-1,0}, //up
        };

        while (queue.Count > 0)
        {
            int size= queue.Count;
            for (int i=0; i<size;i++) //Process all node in the same level
            {
                var (x,y) = queue.Dequeue();
                foreach (var dir in directions)
                {
                    int newX=x+dir[0];
                    int newY=y+dir[1];

                    if (newX>=0 && newY>=0 && newX<rows && newY<cols && grid[newX][newY]==1)
                    {
                        grid[newX][newY]=2;
                        queue.Enqueue((newX,newY));
                        freshCount--;
                    }
                }
            }

            if (queue.Count>0) minutes++;

        }

        return freshCount==0? minutes:-1;
    }
}