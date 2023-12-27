import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Stack;

public class ValidParentheses {

    //[]{}()
    public static  boolean isValid (String s){
        Stack<Character> stack = new Stack<>();
        Map<Character, Character> bracketPairs = new HashMap<>();

        bracketPairs.put(']','[');
        bracketPairs.put(')','(');
        bracketPairs.put('}','{');

        for(char c:s.toCharArray()){
            if (bracketPairs.containsKey(c)){
                char topStackElement= stack.isEmpty()?'#':stack.pop();
                if (topStackElement!=bracketPairs.get(c)) return  false;
            }else {
                stack.push(c);
            }

        }
        return  stack.isEmpty();
    }
}
