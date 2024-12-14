

namespace Technical_Test_Practice
{
    public class MaxBagWithFullCapacity
    {
        public static int Solution (List<int> capacity, List<int> rocks, int additonalRcoks)
        {
            var result=0;
            int i=0;
            while (additonalRcoks>0 && i<capacity.Count)
            {
                while (capacity[i]>rocks[i]){
                    rocks[i]++;
                    additonalRcoks--;
                }
                i++;
                result++;
            }

            while (i<capacity.Count)
            {
                if (capacity[i]==rocks[i])
                {
                    result++;
                }
                i++;
            }
            return result;
            
        }        
    }
}