namespace Technical_Test_Practice;


public class PalindromeSubstring
 {
    public static int CountSubstrings(string s) {
        var sLength= s.Length;
        int count=0;
        for (int i=0; i<sLength; i++){
            int l=i;
            int r=i;

            while (l>=0 && r<sLength && s[l]==s[r] ){
                count ++;
                r++;
                l--;
            }

            l=i;
            r=i+1;
            while (l>=0 && r<sLength && s[l]==s[r] ){
                count ++;
                l--;
                r++;
            }
        }

        return count;
    }
}