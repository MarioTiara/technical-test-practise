public class repeatingCharReplacement {
    public static int characterReplacement(String s, int k){
        int[] freq = new int[26]; // Assuming only uppercase English characters
        int maxLen = 0;
        int maxFreq = 0;
        int start = 0;

        for (int end = 0; end < s.length(); end++) {
            char currentChar = s.charAt(end);
            int charIndex = currentChar - 'A';
            freq[charIndex]++;
            maxFreq = Math.max(maxFreq, freq[charIndex]);

            if ((end - start + 1 - maxFreq) > k) {
                // Shrink the window
                freq[s.charAt(start) - 'A']--;
                start++;
            }

            // Update maxLen
            maxLen = Math.max(maxLen, end - start + 1);
        }

        return maxLen;

    }
}
