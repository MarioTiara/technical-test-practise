from collections import deque
from typing import List

def bfs(grid: List, startX,  startY:int):
    directions=[
        [0,1]
        [0,-1],
        [1,0]
        [-1,0]
    ]
    rows=len(grid)
    cols= len(grid[0])
    visited=[[False for _  in range(cols)] for _ in range (rows)]
    
    que= deque()
    que.append((startX, startY))
    visited[startX][startY]=True
    result=[]
    while deque:
        x, y= que.popleft()
        result.append((x,y))
        for dir in directions:
            newX=x+dir[0]
            newY=y+dir[1]
            
            if newX>=0 and newY>=0 and newX<rows and newY<cols and not visited[newX][newY] and grid[newX][newY]==1:
                visited[newX][newY]=True
                que.append((newX, newY))
    
    return result




        
    