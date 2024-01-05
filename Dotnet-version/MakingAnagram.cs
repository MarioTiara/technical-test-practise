using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class MakingAnagram
    {
        public static int makeAnagram(string a, string b)
        {
            int[] aCount = new int[26];
            int[] bCount = new int[26];

            //populate aCount
            foreach (char c in a.ToCharArray())
            {
                aCount[c - 'a']++;
            }

            //pupulte bCount
            foreach (char c in b.ToCharArray())
            {
                bCount[c - 'a']++;
            }

            int numbOfremove = 0;
            for (int i = 0; i < aCount.Length; i++)
            {
                numbOfremove += Math.Abs(aCount[i] - bCount[i]);
            }

            return numbOfremove;
        }
    }
}