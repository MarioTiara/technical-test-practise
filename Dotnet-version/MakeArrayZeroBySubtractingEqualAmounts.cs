

namespace Technical_Test_Practice
{
    public class MakeArrayZeroBySubtractingEqualAmounts
    {
        public static int Result (List<int> list){
            var nonZeroList= list.Where(p=>p>0).ToList();
            var result=0;
            while (nonZeroList.Count>0){
                var minVal=nonZeroList.Min();
                for (int i=0; i<nonZeroList.Count; i++){
                    nonZeroList[i]-=minVal;
                }
                nonZeroList=nonZeroList.Where(p=>p>0).ToList();
                result++;
            }

            return result;
        }
    }
}