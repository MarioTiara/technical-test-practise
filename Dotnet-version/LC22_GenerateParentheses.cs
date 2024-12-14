namespace Technical_Test_Practice;

public class GenerateParentheses
{
    public static  IList<string> GenrateParentheses(int n)
    {
        var result= new List<string>();
        BackTrack(result, "", 0, 0, n);
        return result;
    }

    private static void BackTrack(List<string> res, string current, int open, int close, int max)
    {
        if (current.Length==max*2)
        {
            res.Add(current);
            return;
        }

        if (open<max)
        {
            BackTrack(res, current+"(", open+1, close, max);
        }
        if (open>close)
        {
            BackTrack(res, current+")", open, close+1, max);
        }
    }
}