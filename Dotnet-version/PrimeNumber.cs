
namespace Technical_Test_Practice
{
    public class PrimeNumber
    {
       public static bool IsPrime(int number){
        //ketika akar dari sebuah bilangan habis dibagi sebuah bilangan
        //dimana bilangan pembagu tersebut berada di rentang 0-akar value
        //maka bilangan tersebut dapat dipastikan bukan sebuah bilangan primer
        //Hal ini dikarenkan ketika sebuah bilangan habis dibagi bilangan akarnya, artinya ada bilangan lain yang juga akan menghasilkan modulus 0 ketika dijadikan pembai
        //contoh:
        // 12-> akar dari 12 adalah 3.464
        // modulus dari 12%3 adalah 0
        //Artinya 3 adalah faktor pembagi dari 12 dimana angka 4 juga akan menjadi modulus 0 dari 12 karena: 12/3= 4

        if (number<2) return false;
        var squareVal= Math.Sqrt(number);
        for (int i=1; i<= squareVal; i++){
            if (number%i==0) return false;
        }

        return true;
       
       }
    

    public static bool IsPrimerNumber2(int number){
        //sebuah prime number akan habis dibagi satu dan dibagi bilangan itu sendiri
        //Artinya hanya ada dua bilangan yang menghasilkan modulus 0 jika dijadikan pembagi dari sebuah bilangan primer
        //Bilangan tersebut adalah angka 1 dan bilangan itu sendiri

        var divider=0;
        for (int i=1; i<=number; i++){
            if (number%i==0) divider++;
        }

        return divider==2? true: false;
    }

    }

   
}