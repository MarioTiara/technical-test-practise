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
        public static string GetMinWindows(string s, string t){
            if (t=="") return "";
            if (s.Length<t.Length) return "";

            var countT = new Dictionary<char, int>();
            var window = new Dictionary<char, int>();
            
            foreach (var c in t.ToCharArray()) {
                if (countT.ContainsKey(c)) countT[c]+=1;
                else countT.Add(c,1);
            }

            int have=0;
            int need = t.Length;

            int [] result= new int[2]{-1,-1};
            int resLen = int.MaxValue;

            int l=0;
            //int r=0;
            for (int r=0; r<s.Length; r++ ){
                var c= s[r];
                if (window.ContainsKey(c)) window[c]++;
                else window.Add(c, 1);

                if (countT.ContainsKey(c) && window[c]==countT[c]) have+=1;
                while (have==need){
                    var leftChar= s[l];
                    //udate result
                    if ((r-l+1)<resLen){
                        result[0]=l;
                        result[1]=r;
                        resLen=(r-l+1);
                    }
                    window[leftChar]-=1;
                    if (countT.ContainsKey(leftChar) && window[leftChar]<countT[leftChar]){
                        have-=1;
                    }
                    l+=1;
                }
            }
                
            

            return s.Substring(result[0], (result[1]-result[0]+1));
        

        }

        private static bool isWindowHaveWhatWeNeed(Dictionary<char, int> tCount, Dictionary<char, int> wCount){
            foreach (var k in tCount.Keys){
                if (tCount[k]>wCount[k]) return false;
            }

            return true;
        }
    }
}