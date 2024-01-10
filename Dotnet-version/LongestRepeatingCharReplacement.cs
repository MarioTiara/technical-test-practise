using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class LongestRepeatingCharReplacement
    {
        public static int CharacterReplacement(string s, int k)
        {

            var tCount = new Dictionary<char, int>();
            int maxLen = int.MinValue;

            for (int l = 0; l < s.Length; l++)
            {
                var currentChar = s[l];
                int change = 0;
                int currentLen = 1;
                int r = l + 1;

                while (change <= k && r < s.Length)
                {
                    var leftChar = s[r];
                    if (currentChar != leftChar)
                    {
                        change++;
                    }
                    if (change<=k) currentLen++;
                    r++;

                }

                maxLen = Math.Max(maxLen, currentLen);
            }

            return maxLen;
        }
    }
}