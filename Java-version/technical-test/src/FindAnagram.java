import java.util.ArrayList;
import java.util.List;

public class FindAnagram {
    public static List<Integer> findAnagrams(String s, String p){
        List<Integer> result= new ArrayList<>();
        if (s==null || p== null || s.length()<p.length()){
            return  result;
        }

        //26 indicate numbers of char A-Z
        int[] charCountP= new int[26];
        int[] charCountWindow= new int[26];

        //Count the freq of characters in p
        for (char ch:p.toCharArray()){
            charCountP[ch-'a']++;
        }

        //initialize the sliding window
        for (int i =0; i<p.length(); i++){
            charCountWindow[s.charAt(i)-'a']++;
        }

        //check the anagram for the initial window
        if (areArraysEqual(charCountP, charCountWindow)){
            result.add(0);
        }

        for (int i= p.length(); i<s.length(); i++){
            var charToReduce=s.charAt(i-p.length());
            charCountWindow[charToReduce-'a']--;

            var charToAdd=s.charAt(i);
            charCountWindow[charToAdd-'a']++;

            if (areArraysEqual(charCountP, charCountWindow)){
                result.add(i-p.length()+1);
            }
        }

        return  result;
    }

    private  static boolean areArraysEqual (int[] arr1, int [] arr2){
        for (int i=0; i<arr1.length; i++){
            if (arr1[i]!= arr2[i]) return false;
        }

        return  true;
    }
}


