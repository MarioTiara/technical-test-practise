from  typing import List
import unittest

class Solution:
    def asteroidCollision(self, asteroids: List[int]) -> List[int]:
        stack=[]
        for a in asteroids:
            while stack and a<0<stack[-1]:
                if stack[-1] < -a:
                    stack.pop()
                    continue
                elif stack[-1]==-a:
                    stack.pop()
                
                break
            else:
                stack.append(a)
                
        
        return stack



class Test(unittest.TestCase):
    def test_asteroid(self):
        sln=Solution()
        self.assertEqual(sln.asteroidCollision([10,2,-5]), [10])
        self.assertEqual(sln.asteroidCollision([5,10,-5]), [5,10])
        self.assertEqual(sln.asteroidCollision([5,-5]), [])
        self.assertEqual(sln.asteroidCollision([-5,-2,4,6]), [-5,-2,4,6])
        self.assertEqual(sln.asteroidCollision([-2,-2,1,-2]), [-2,-2,-2])
        self.assertEqual(sln.asteroidCollision([-2,-2,1,-1]), [-2,-2])


if __name__ == '__main__':
    unittest.main()

    