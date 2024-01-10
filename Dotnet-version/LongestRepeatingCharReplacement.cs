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
                if (!tCount.ContainsKey(currentChar))
                {
                    int change = 0;
                    tCount[currentChar] = 1 + tCount.GetValueOrDefault(currentChar, 0);
                    int r = l + 1;
                    while (change <= k && r < s.Length)
                    {
                        var leftChar = s[r];
                        if (currentChar == leftChar)
                        {
                            tCount[currentChar] = 1 + tCount.GetValueOrDefault(currentChar, 0);
                        }
                        else
                        {
                            change++;
                        }

                        if (change == k && currentChar != leftChar)
                        {
                            tCount[currentChar] += change;
                        }

                        r++;

                    }

                    maxLen = Math.Max(maxLen, tCount[currentChar]);
                }



            }

            return maxLen;
        }
    }
}