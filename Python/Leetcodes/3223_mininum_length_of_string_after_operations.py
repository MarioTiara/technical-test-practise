class Solution:
    def minimumLength(self, s:str)->int:
        # count frequency
        map= {}
        for c in s:
            if c not in map:
                map[c]=0
            map[c]+=1

        
        operation=True
        while(operation):
            operation=False
            for c in map:
                if (map[c]>=3):
                    map[c]-=2
                    operation=True
        
        return sum(map.values())


sol= Solution()
res=sol.minimumLength("abaacbcbb")

print (res)