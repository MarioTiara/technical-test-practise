using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class MigratoryBird
    {
        public static int migratoryBirds(List<int> arr){
            var birdFreqMap= new Dictionary<int, int>();

            foreach (var num in arr){
                if (!birdFreqMap.ContainsKey(num)){
                    birdFreqMap.Add(num, 1);
                }else {
                    birdFreqMap[num]++;
                }
            }

            var result= birdFreqMap.Keys.First();
            foreach (var b in birdFreqMap.Keys){
                if (result!= b && birdFreqMap[b]> birdFreqMap[result]){
                    result=b;
                }
               else if (result!= b && birdFreqMap[b]==birdFreqMap[result]){
                    result=Math.Min(result, b);
                }
            }

            return result;
        }
    }
}