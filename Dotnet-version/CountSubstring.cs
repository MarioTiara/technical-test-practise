using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class CountSubstring
    {
        public static int Count(string s)
        {
            var substring= new List<string>();
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int l = i, r = i;
                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    count++;
                    substring.Add (s.Substring(l, r-l+1));
                    l--;
                    r++;
                }

                l = i;
                r = i + 1;
                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    count++;
                    substring.Add (s.Substring(l, r-l+1));
                    l-=1;
                    r+=1;
                }
            }

            return count;
        }
    }
}