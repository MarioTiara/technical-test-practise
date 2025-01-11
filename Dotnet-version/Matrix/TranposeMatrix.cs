namespace Matrix;

public class TranposeMatrix
{
    public static void Tranpose(int [][] matrix)
    {
        for (int i=0; i<matrix.Length; i++)
        {
            for (int j=i+1; j<matrix[i].Length; j++)
            {
                var temp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = temp; 
            }
        }

// ......1x1.
// 11..11211.
// x2..1x1...
// x3..111...
// x421....11
// 2xx1....1x
// 2321....11
// x1........
// 11.1221...
// ...1xx1...
    }
}