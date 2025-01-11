namespace Technical_Test_Practice;

public class CaesarChipper
{
    public static string Run (string s, int k)
    {
        k%=26;
        char [] result = new char[s.Length];

        for (int i=0; i<s.Length; i++)
        {
            char c=s[i];
            if (char.IsLower(c))
            {
                result[i] = (char)((c-'a'+k)%26+'a');
            }
            else if (char.IsUpper(c))
            {
                result[i] = (char)((c-'A'+k)%26+'A');
            }
        }

        return new string(result);
    }
}