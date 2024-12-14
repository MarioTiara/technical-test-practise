namespace Technical_Test_Practice;

public class RotateMatrix90
{
    public static int [,] Rotate(int[][] matrix)
    {
        var hash= new HashSet<int>();
        
        int [,] result = new int[matrix.Length, matrix.Length];

        int right=matrix.Length-1;
        int buttom=result.Length-1;


        foreach (var arr in matrix)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                result[i,right]=arr[i];
            }
            right--;
        }

        return result;

    }

    public static void OnplaceRotate(int[][] matrix)
    {
        Transpose(matrix);
        Reverese(matrix);
    }
    public static void Transpose(int[][] matrix)
    {
        for (int r=0; r<matrix.Length; r++){
            for (int c=r; c<matrix[0].Length; c++){
                int temp= matrix[r][c];
                matrix[r][c]=matrix[c][r];
                matrix[c][r]=temp;
            }

        }
    }

    public static void Reverese(int[][] matrix)
    {
        for (int r=0; r<matrix.Length; r++){
            Array.Reverse(matrix[r]);
        }
    }
}