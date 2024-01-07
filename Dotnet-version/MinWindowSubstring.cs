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
            if (s.Length<t.Length) return "";

            var tCount= new Dictionary<char, int>();
            var WindCount= new Dictionary<char, int>();
            int minLength=int.MaxValue;
            int [] SubsIndex={0,0};
            List<char> subStrings= new (); 
            
            //initt WindCount
            foreach (char c in t.ToCharArray()){
                tCount.Add(c,1);
                WindCount.Add(c,0);
            }

            int left=0;
            int rigth=0;
            //get initial minWindow
            while (!isWindowSame(tCount, WindCount)){
                var c=s[rigth];
                if (WindCount.ContainsKey(c)){
                    WindCount[c]++;
                }
                rigth++;
            }

            SubsIndex[0]=left;
            SubsIndex[1]=rigth;
            minLength=rigth-left;
            while(rigth<s.Length){
                var c=s[rigth];
                if (WindCount.ContainsKey(c)){
                    WindCount[c]++;
                }
                while (isWindowSame(tCount, WindCount)){
                    if (minLength> (rigth-left)){
                        SubsIndex[0]=left;
                        SubsIndex[1]=rigth;
                    }
                    var ch=s[left];
                    if (WindCount.ContainsKey(ch))WindCount[ch]--;
                    left++;
                }

                rigth++;
            }
            left--;
            rigth--;
            return s.Substring(left, rigth-left+1);
        

        }

        private static bool isWindowSame(Dictionary<char, int> tCount, Dictionary<char, int> wCount){
            foreach (var k in tCount.Keys){
                if (tCount[k]>wCount[k]) return false;
            }

            return true;
        }
    }
}