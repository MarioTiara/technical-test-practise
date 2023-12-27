using System.Text.Json;

namespace Technical_Test_Practice
{
    //     Example 1:

    // Input: s = "abcabcbb"
    // Output: 3
    // Explanation: The answer is "abc", with the length of 3.
    // Example 2:

    // Input: s = "bbbbb"
    // Output: 1
    // Explanation: The answer is "b", with the length of 1.
    // Example 3:

    // Input: s = "pwwkew"
    // Output: 3
    // Explanation: The answer is "wke", with the length of 3.
    // Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

    public static class LongestSubstring
    {
        public static int LengthOfSubstring(string s){
            List<HashSet<char>> subStrings= new ();
            foreach (var c in s){

                if (subStrings.Count<=0){
                    subStrings.Add(new HashSet<char>{c});
                    continue;
                }

                //subStrings[0].Add('c');
                if (subStrings.Count>=0 && !subStrings[subStrings.Count-1].Contains(c)){
                    subStrings[subStrings.Count-1].Add(c);
                    continue;
                }

                if (subStrings.Count>=0 && subStrings[subStrings.Count-1].Contains(c)){
                    var lastChar= subStrings.Last().Last();
                      subStrings.Add(new HashSet<char>{lastChar,c});
                      
                      continue;
                }
            }
            Console.WriteLine (JsonSerializer.Serialize (subStrings));
            var lenght=subStrings?.MaxBy(p=>p.Count)?.Count;
            return lenght??0;
        }

        public static int LengthOfSubstring2(string s)
        {
            int a_pointer=0;
            int b_pointer=0;
            int max=0;

            HashSet<char> has_set= new ();
            while (b_pointer<s.Length){
                if (!has_set.Contains (s[b_pointer])){
                    has_set.Add(s[b_pointer]);
                    b_pointer++;
                    max=Math.Max(has_set.Count, max);
                }
                else {
                    has_set.Remove(s[a_pointer]);
                    a_pointer++;
                }
            }

            Console.WriteLine (JsonSerializer.Serialize (has_set));

            return max;
        }
    }
}