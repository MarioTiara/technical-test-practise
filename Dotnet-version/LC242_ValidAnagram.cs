using Technical_Test_Practice;

public class ValidAnagram
{
    public static bool IsAnagram(string s, string t)
    {
        var sCharTable= new int[26];
        foreach(var c in s.ToLower()){
            sCharTable[c-'a']++;
        }

        var tCharTable= new int [26];
        foreach(var c in t.ToLower()){
            tCharTable[c-'a']++;
        }

        int i=0;
        while(i<26){
            if (sCharTable[i]!=tCharTable[i]){
                return false;
            }
            i++;
        }

        return true;
    }
}