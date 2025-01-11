
public class CaesarKripto {

    public static String run (String s , int k)
    {
         k%=26;
         int l=s.length();
         char [] result = new char[l];
         for (int i=0; i<l; i++)
         {
            char c=s.charAt(i);
            if (Character.isLowerCase(c))
            {
                result[i]=(char)((c-'a'+k)%26 +'a');
            }
            else if (Character.isUpperCase(c))
            {
                result[i]=(char)((c-'A'+k)%26 +'A');
            }
         }
        return new String(result);
    }
}
