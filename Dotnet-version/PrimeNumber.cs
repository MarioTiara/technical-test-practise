
namespace Technical_Test_Practice
{
    public class PrimeNumber
    {
        static bool IsPrime(int number){
        if (number<2){
            return false;
        }

        var maxValue= Math.Sqrt(number);
        
        for (int i=2; i<= Math.Sqrt(number); i++){
            if (number % i==0) return false;
        }

        return true ;
    }

    static bool IsPrimerNumber2(int number){
        int div=0;

        for (int i=1; i<=number; i++){
            if (number%i==0) div++;
        }
        Console.WriteLine(div);
        return div==2?true:false;
    }

    }

   
}