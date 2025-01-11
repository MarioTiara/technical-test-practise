namespace Komoro.test;

public class Q2
{

    public static void Run(int n)
    {
        //Console.WriteLine("*");
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine();
            for (int k = 1; k <= i; k++)
            {
                Console.Write("*");
            }

        }
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine();

            int j = i;
            while (j <= n - 1)
            {
                Console.Write("*");
                j++;
            }

        }
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine();
             for (int j=n-i; j >0; j--)
            {
                Console.Write(" "); 
            }
            for (int j=0; j < i; j++)
            {
                Console.Write("*");
            }
        }
         for (int i = 1; i <= n; i++)
        {
            Console.WriteLine();
              for (int j=0; j < i; j++)
            {
                Console.Write(" ");
            }
             for (int j=n-i; j >0; j--)
            {
                Console.Write("*"); 
            }
          
        }
        



    }
}