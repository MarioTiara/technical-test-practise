

namespace Technical_Test_Practice
{
    public class SwapCan
    {
        public static bool Iscan(string str1, string str2)
        {
            str1 = str1.ToLower();
            str2 = str2.ToLower();
            int length = str1.Length;
            int notEqualCount = 0;
            for (int i = 0; i < length; i++)
            {
                if (str1[i] != str2[i])
                    notEqualCount++;
            }

            return notEqualCount <= 2;
        }
    }
}