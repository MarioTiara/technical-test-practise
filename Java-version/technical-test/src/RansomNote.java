import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;

public class RansomNote {

//    Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.
//    Each letter in magazine can only be used once in ransomNote.
//    Example 1:
//    Input: ransomNote = "a", magazine = "b"
//    Output: false

//    Example 2:
//    Input: ransomNote = "aa", magazine = "ab"
//    Output: false
//    Example 3:

//    Input: ransomNote = "aa", magazine = "aab"
//    Output: true

    public static boolean canConstruct(String ransomNote, String magazine) {
        Map<Character, Integer> map1= new HashMap<>();
        Map<Character, Integer> map2= new HashMap<>();

        for (char c: ransomNote.toCharArray()){
            if (!map1.containsKey(c)) map1.put(c, 1);
            else {
                var val=map1.get(c)+1;
                map1.put(c,val);
            }
        }

        for (char c: magazine.toCharArray()){
            if (!map2.containsKey(c)) map2.put(c, 1);
            else {
                var val=map2.get(c)+1;
                map2.put(c,val);
            }
        }

        for( var entry:map1.entrySet()){
            if(!map2.containsKey(entry.getKey())) return false;
            var va1=entry.getValue();
            var val2=map2.get(entry.getKey());

            if (va1>val2)  return  false;
        }

        return  true;
    }
}
