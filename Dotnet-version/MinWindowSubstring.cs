using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class MinWindowSubstring
    {
        public static string GetMinWindows(string s, string t)
        {
            if (t == "") return "";


            var countT = new Dictionary<char, int>();
            var window = new Dictionary<char, int>();

            foreach (char c in t)
            {
                countT[c] = 1 + countT.GetValueOrDefault(c, 0);
            }

            int have = 0;
            int need = countT.Count;

            int[] result = new int[2] { -1, -1 };
            int resLen = int.MaxValue;

            int l = 0;
            //int r=0;
            for (int r = 0; r < s.Length; r++)
            {
                var c = s[r];
                window[c] = 1 + window.GetValueOrDefault(c, 0);

                if (countT.ContainsKey(c) && window[c] == countT[c])
                {
                    have++;
                }
                while (have == need)
                {
                    //udate result
                    if ((r - l + 1) < resLen)
                    {
                        result[0] = l;
                        result[1] = r;
                        resLen = (r - l + 1);
                    }
                    window[s[l]]--;
                    if (countT.ContainsKey(s[l]) && window[s[l]] < countT[s[l]])
                    {
                        have--;
                    }
                    l++;
                }
            }


            int left = result[0];
            int right = result[1];
            return (resLen != int.MaxValue) ? s.Substring(left, right - left + 1) : "";


        }

        private static bool isWindowHaveWhatWeNeed(Dictionary<char, int> tCount, Dictionary<char, int> wCount)
        {
            foreach (var k in tCount.Keys)
            {
                if (tCount[k] > wCount[k]) return false;
            }

            return true;
        }
    }
}