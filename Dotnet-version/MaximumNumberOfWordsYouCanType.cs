

namespace Technical_Test_Practice
{
    public class MaximumNumberOfWordsYouCanType
    {
        public static int Result (string text, string broken){
            var words= text.Split (' ');
            var bokrenWordCount=0;
            foreach (var word in words){
                foreach (char c in broken){
                    if (word.Contains(c)){
                        bokrenWordCount++;
                        break;
                    }
                        
                }
            }

            return  words.Length-bokrenWordCount;
        }
    }
}