using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class MinWindowSubstring
    {
        public static string GetMinWindows(string s, string t){
            if (s==t) return s;
            if (t.Length>s.Length) return "";
            var tCount = new Dictionary<char, int>();
            var windowCount =new Dictionary<char, int>();

            //init table values
            foreach (var c in t.ToCharArray()) {
             tCount.Add(c,1);
             windowCount.Add(c,0);   
            }

            var result= new int[2]{0,0};
            var left=0;
            var right=0;
            var minLength=int.MaxValue;
            var indexs= new int[2]{0,0};

            while (right<s.Length){

                var ch= s[right];
                if (tCount.ContainsKey(ch)){
                    windowCount[ch]++;
                }

                while (isWindowHaveWhatWeNeed(tCount, windowCount)){
                    var curLength= right-left;
                    if (minLength>curLength){
                        result[0]=left;
                        result[1]=right;
                        minLength=curLength;
                    }

                    var rightChar= s[left];
                    if (windowCount.ContainsKey(rightChar)){
                        windowCount[rightChar]--;
                    }

                    left++;
                }

                right++;
            }
            left--;
            right--;
            return s.Substring(left, right-left+1);
        

        }

        private static bool isWindowHaveWhatWeNeed(Dictionary<char, int> tCount, Dictionary<char, int> wCount){
            foreach (var k in tCount.Keys){
                if (tCount[k]>wCount[k]) return false;
            }

            return true;
        }
    }
}