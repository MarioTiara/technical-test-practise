public class LongestPalindromicSubstring {
    public String longestPalindrome(String s){
        if (isPalindrome(s.toCharArray())) return  s;
        return  s;
    }

    private  boolean isPalindrome(char[] subStrings){
        int i=0;
        int r=subStrings.length-1;

        while (i<=r){
            while (Character.isLetterOrDigit(subStrings[i])) i++;
            while (Character.isLetterOrDigit(subStrings[r])) r--;
            if (subStrings[i]!=subStrings[r]) return  false;
        }
        return  true;
    }
}
