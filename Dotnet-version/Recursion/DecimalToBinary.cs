namespace Technical_Test_Practice.Recursion;

public class DecimalToBinary
{
    public static string FindBinary(int number, string result)
    {
        if (number ==0) return result;

        result= number%2+result;
        return FindBinary(number/2, result);
    }
}