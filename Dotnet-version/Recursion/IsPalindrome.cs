namespace Technical_Test_Practice.Recursion;

public class Palindrome
{
    public static bool IsPalindrome (String input){
        if (input.Length<=1)
        {
            return true;
        }

        if (input[0]==input[input.Length-1])    
        {
            return IsPalindrome(input.Substring(1, input.Length-2));
        }
        return false;
    }
}