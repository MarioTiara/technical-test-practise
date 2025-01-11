using System.Text.Json;

namespace Matrix;

public class MatrixToZero
{
    public static void SetToZero(int[][] matrix)
    {
        var rows= new bool[matrix.Length];
        var cols= new bool[matrix.Length];

        for (int i=0; i<matrix.Length; i++)
        {

            for (int j=0; j<matrix[i].Length; j++)
            {
                Console.Write(matrix[i][j]+" ");
                if (matrix[i][j]==0)
                {
                    rows[i]=true;
                    cols[j]=true;
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine(JsonSerializer.Serialize(rows));
        Console.WriteLine(JsonSerializer.Serialize(cols));

        //Set rows to zero
        for (int i=0; i<matrix.Length; i++)
        {
            if (rows[i] == true)
            {
                for (int j=0; j<matrix[i].Length; j++)
                {
                    matrix[i][j]=0;
                }
            }
        }

        for (int i=0; i<matrix.Length; i++)
        {
            for (int j=0; j<matrix.Length; j++)
            {
                if (cols[j]==true)
                {
                    matrix[i][j]=0;
                }
            }
        }

        Console.WriteLine(JsonSerializer.Serialize(matrix));
     
    }
}