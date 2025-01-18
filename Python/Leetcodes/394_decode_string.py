class Solution:
    def decodeString(self, s: str) -> str:
        stack=[]
        current_num=0
        current_string=""
        
        for c in s:
            if c.isdigit():
                current_num=current_num*10+int(c)
            elif c=='[':
                stack.append((current_string, current_num))
                current_num=0
                current_string=""                
            elif c==']':
                prev_string, number=stack.pop()
                current_string=prev_string+number*current_string
            else:
                current_string+=c
        
        return current_string
            
            
                
                
        
            
    
    
# s = "3[a]2[bc]"
s = "3[a2[c]]"

sln=Solution()
result=sln.decodeString(s)

print (result)