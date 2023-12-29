
using System.Text.RegularExpressions;

namespace Technical_Test_Practice
{
    public static class ValidPalindrome
    {
        public static bool isPalindrome(string words)
        {
            var l=0;
            var r=words.Count()-1;

            while (l<r)
            {
                while (l<r && !alphaNum(words[l])) {
                    l++;
                }
                while (r>l && !alphaNum(words[r])){
                  r--;  
                } 
                if (words[l].ToString().ToLower() != words[r].ToString().ToLower()) return false;
                l++;
                r--;
            }

            return true;
        }

        private static bool alphaNum(char c)
            => char.IsLetter(c) || char.IsNumber(c);
    }
}