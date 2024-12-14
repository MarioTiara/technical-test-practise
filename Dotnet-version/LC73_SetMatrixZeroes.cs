namespace Technical_Test_Practice;

public class SetMatrixZeroes
{
    public static void SetZeroes(int[][] matrix)
    {
        int rows = matrix.Length;
        int columns=matrix[0].Length;

        bool firstRowZero= false;
        bool firstColumnZero= false;

        for (int i=0;i<rows;i++)
        {
            if (matrix[i][0] == 0){
                firstRowZero=true;
                break;
            }
        }


        for (int i=0;i<columns;i++)
        {
            if (matrix[0][i] == 0){
                firstColumnZero=true;
                break;
            }
        }

        // marks all the first rows and columns that need to be zeroed
        for (int i=1; i<rows;i++)
        {
            for(int j=1;j<columns;j++)
            {
                if (matrix[i][j] == 0){
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }


        // zeroes all the rows and columns except the first row and column
        for (int i=1; i<columns;i++)
        {
            for(int j=1;j<rows;j++)
            {
                if (matrix[i][0] == 0 || matrix[0][j] == 0){
                    matrix[i][j] = 0;
                }
            }
        }

        // zeroes the first row and column if needed
        if (firstRowZero){
            for (int i=0;i<rows;i++)
            {
                matrix[i][0] = 0;
            }
        }

        if (firstColumnZero){
            for (int i=0;i<columns;i++)
            {
                matrix[0][i] = 0;
            }
        }





    }
}