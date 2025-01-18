from typing import List

class Solution:
    def longestSubarray(self, nums: List[int]) -> int:
        j=0
        max_length=0
        zero_count=0
        for i in range (len(nums)):
            if nums[i]==0:
                zero_count+=1

            while zero_count>1:
                if nums[j]==0:
                    zero_count-=1
                j+=1
            
            length= i-j-1
            max_length=max(max_length, length)
            print(f"j:{j}, i:{i}, length:{length}")
        return length

sln= Solution()

nums = [0,1,1,1,0,1,1,0,1]

result=sln.longestSubarray(nums)

