namespace Technical_Test_Practice;

public class ValidSudoku
{
    public static bool IsValid(char[][] board)
    {
        //Check row valid
        
        for (int i=0; i<board.Length; i++)
        {
            var rows= new HashSet<char>();
            for (int j=0; j<board[i].Length; j++)
            {
                var value= board[j][i];
                if (value=='.') continue;
                if (rows.Contains(value)){
                    return false;
                }
                rows.Add(value);
            }
        }

        //check column valid
        for (int i=0; i<board.Length; i++)
        {
            var cols= new HashSet<char>();
            for (int j=0; j<board[i].Length; j++)
            {
                var value= board[i][j];
                if (value=='.') continue;
                if (cols.Contains(value)){
                    return false;
                }
                cols.Add(value);
            }
        }

        //check 3x3 valid
        for (int i=0; i<board.Length; i+=3)
        {
            for (int j=0; j<board[i].Length; j+=3)
            {
                var values= new HashSet<char>();
                for (int k=i; k<i+3; k++)
                {
                    for (int l=j; l<j+3; l++)
                    {
                        var value= board[k][l];
                        if (value=='.') continue;
                        if (values.Contains(value)){
                            return false;
                        }
                        values.Add(value);
                    }
                }
            }
        }

        return true;
    }
}