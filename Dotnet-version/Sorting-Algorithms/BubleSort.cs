

namespace Technical_Test_Practice.Sorting_Algorithms;

public class BubleSort
{
    public static void Sort(int[] arr)
    {
        bool isSorted = false;
        while (!isSorted)
        {

            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    isSorted = false;
                    Swap(arr, i, i + 1);

                }
            }

        }
    }



    private static void Swap(int[] arr, int i, int j)
    {
        var temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}