
namespace Technical_Test_Practice
{
    public class InsertingSort
    {

        //var a = [4, -31, 0, 99, 83, 1];
        public static void Sort(int[] arr)
        {
            for (int i=0; i<arr.Length; i++)
            {
                var currentUnsorted= arr[i];
                int j=i;
                while (j>0 && currentUnsorted<arr[j-1]){
                    arr[j]=arr[j-1];
                    j--;
                }

                arr[j]=currentUnsorted;
            }
        }
    }
}