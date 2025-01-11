using Microsoft.VisualBasic;

namespace Komoro.test;

public class Q3
{
    public static void Run(int n)
    {
        var db= new Dictionary<int, string>()
        {
            { 1, "Satu" },
            { 2, "Dua" },
            { 3, "Tiga" },
            { 4, "Empat" },
            { 5, "Lima" },
            { 6, "Enam" },
            { 7, "Tujuh" },
            { 8, "Delapan" },
            { 9, "Sembilan" },
        };

        //Hangdle ribuan
        if (n>=1000)
        {
            var ribuan=n/1000;
            var sisa=n%1000;
            if (ribuan>=10)
            {
                var puluhan=ribuan/10;
                var sisa2=ribuan%10;
                 Console.WriteLine(db[puluhan]+" Puluh");
                 Console.WriteLine(db[sisa2]);
            }
            Console.WriteLine("Ribu");

        }






    }
}