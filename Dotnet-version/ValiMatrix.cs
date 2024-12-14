using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class ValiMatrix
    {
        public static bool Solution (List<List<int>> inputmatrix)
        {
            var mapVal= new Dictionary<int, int>();
            foreach (var list in inputmatrix)
            {
                foreach (var item in list)
                {
                    if (!mapVal.ContainsKey(item)){
                        mapVal[item] = 0;
                    }
                    mapVal[item]++;
                }
            }

            var valCount=mapVal.FirstOrDefault().Value;
            for (int i=1; i<mapVal.Count; i++)
            {
                if (valCount!= mapVal[i])
                 return false;
            }

            return true;
            
        }
    }
}