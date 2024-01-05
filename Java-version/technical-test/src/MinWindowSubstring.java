public class MinWindowSubstring {
    public static String minWindow(String s, String t) {
        int [] windowCount = new int[24];
        int []TCount = new int[24];

        int have=0, need=t.length(),leftPointer=0, rightPointer=0;;
        int minLen=Integer.MAX_VALUE;

        //Define T table
        for (var c:t.toCharArray()){
            TCount[c-'A']++;
        }

        while (rightPointer<=s.length()){
            while (have!=need){
                windowCount[s.charAt(rightPointer)-'A']++;
                if (TCount[s.charAt(rightPointer-'A')]==windowCount[s.charAt(rightPointer-'A')]){
                    
                }
            }
        }

        return "";
    }
}
