

using System.Data.SqlTypes;
using System.Net.NetworkInformation;

namespace Technical_Test_Practice
{
    public class WorldPattern
    {
        public static bool IsSamePattern(string pattern, string s)
        {
            var patternVal = new Dictionary<char, int>();
            int valCand = 0;
            var pInt= new List<int>();
            foreach (char c in pattern)
            {
                if (!patternVal.ContainsKey(c))
                {
                    patternVal.Add(c, valCand);
                    valCand++;
                }
                pInt.Add(patternVal[c]);
            }

            var splitedS = s.Split(" ");
            valCand=0;
            var sVal= new Dictionary<string, int>();
            var sInt = new List<int>();
            foreach (var w in splitedS){
                if (!sVal.ContainsKey(w)){
                    sVal.Add(w, valCand);
                    valCand++;
                }
                 sInt.Add(sVal[w]);
            }

            for (int i=0; i<sInt.Count; i++){
                if (pInt[i]!= sInt[i])
                    return false;
            }
            return true;
        }
    }
}