namespace Komoro.test;

public class Q1
{
    public static void Run (int n)
    {

        for (int i=n; i>0; i--)
        {
            Console.WriteLine ();
            for(int j=n; j>0; j--)
            {
                for (int k=0; k<i; k++)
                {
                    Console.Write(j);
                }
            }
        }
    }
}