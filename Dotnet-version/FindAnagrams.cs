using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class FindAnagrams
    {
        public  static List<int> findAnagrams(String s, String p){
            List<int> result= new List<int>();

            if (s==null || p== null || s.Length<p.Length) return result;

            int[] charCountP= new int[26];
            int[] charCountWindow= new int[26];

        
            //Count the frequency of characters in p
            foreach(char c in p){
                charCountP[c-'a']++;
            }

            //Initialize the sliding window
            for (int i=0; i<p.Length; i++){
                charCountWindow[s[i]-'a']++;
            }

            //Check innitial array
            if (areArraysEqual(charCountP, charCountWindow)) result.Add(0);

            //Move the sliding windows
            for (int i=p.Length; i<s.Length; i++){
                Console.WriteLine(i);
                charCountWindow[s[i-p.Length]-'a']--;
                charCountWindow[s[i]-'a']++;

                if (areArraysEqual(charCountP, charCountWindow)){
                    result.Add(i-p.Length+1);
                }
            }

            return result;

        }

        private static bool areArraysEqual(int[] arr1, int[] arr2){
            for (int i=0; i<arr1.Length; i++){
                if (arr1[i]!=arr2[i]) return false;
            }

            return true;
        }
    }
}