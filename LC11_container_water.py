from typing import List
 

class Solution:
    def maxArea(self, height: List[int]) -> int:
        maxWater=0
        l=0
        r= len(height)-1
        while (l<r):
            area=0
            ln=r-l
            if height[l]<=height[r]:
                area=ln*height[l]
                l+=1
            elif height[l]>height[r]:
                area=ln*height[r]
                r-=1
            maxWater= max(maxWater, area)
        
        return maxWater



height=[1,8,6,2,5,4,8,3,7]

sln=Solution()
sln.maxArea(height)

height.sort()

map={}
map

print(floor)

map.get