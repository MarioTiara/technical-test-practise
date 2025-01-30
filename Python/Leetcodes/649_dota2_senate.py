

from collections import deque

class Solution:
    def predictPartyVictory(self, senate: str) -> str:
        radiant=deque()
        dire=deque()
        
        for i,c in enumerate(senate):
            if c=='R':
                radiant.append(i)
            else:
                dire.append(i)
        
        n=len(senate)
        while radiant and dire:
            r=radiant.popleft()
            d=dire.popleft()
            
            if r<d:
                radiant.append(r+n)
            else:
                dire.append(d+n)
        return "Radiant" if radiant else "Dire"


p=Solution()

print (p.predictPartyVictory("DDRRR"))
print (p.predictPartyVictory("RDD"))
print (p.predictPartyVictory("RD"))
print (p.predictPartyVictory("DRDRR"))


