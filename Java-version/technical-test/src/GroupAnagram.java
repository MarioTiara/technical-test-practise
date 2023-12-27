import java.util.*;

public class GroupAnagram {
    public static List<List<String>> groupsAnagram(String[] strs) {
        Map<String, List<String>> anagrams= new HashMap<>();

        for (String s :strs){
             char[] chr=s.toCharArray();
             Arrays.sort(chr);
             String newStr= new String(chr);

             if (!anagrams.containsKey(newStr)){
                 anagrams.put(newStr, new ArrayList<>());
             }
             anagrams.get(newStr).add(s);
        }

        List<List<String>> result= new ArrayList<>(anagrams.values());
        return  result;
    }


}
