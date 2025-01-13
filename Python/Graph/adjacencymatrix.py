

from collections import deque


class Graph:
    def __init__(self, vertices:int):
        self.vertices=vertices
        self.matrix=[[0]*vertices for _ in range(vertices)]
        
    def add_edge(self, i:int, j:int):
       self.matrix[i][j]=1
       self.matrix[j][i]=1
    
    def disply(self):
        for row in self.matrix:
            print(row)
    
    def DFS(self, start:int):
        visited=[False]*self.vertices
        result=[]
        
        def dfs_recursive(v):
            visited[v]=True
            result.append(v)
            for i in range (self.vertices):
                if not visited[i] and self.matrix[v][i]==1:
                    dfs_recursive(i)
        dfs_recursive(start)
        return result

    def BFS (self, start:int):
        visited=[False]*self.vertices
        result=[]
        
        visited[start]=True
        q=deque()
        q.append(start)
        while (len(q)>0):
            v=q.popleft()
            result.append(v)
            for n in range (self.vertices):
                if self.matrix[v][n]==1 and not visited[n]:
                    visited[n]=True
                    q.append(n)
        
        return result

    def BFS_Grid (self, startX:int, startY:int):
        rows=len(self.matrix)
        cols= len(self.matrix[0])
        result=[]
        visited=[[False for _ in range (cols) ] for _ in range (rows)]
        q=deque()
        
        q.append((startX, startY))
        visited[startX][startY]==True
        
        directions=[
            [0,1],
            [0,-1],
            [1,0],
            [-1,0]
            ]
        while (len(q)>0):
            x,y= q.popleft()
            result.append((x,y))
            for dir in directions:
                newX= x+dir[0]
                newY=y+dir[1]
                
                if newX>=0 and newY>=0 and newX<rows and newY<cols and not visited[newX][newY] and self.matrix[newX][newY]==1:
                    visited[newX][newY]=True   
                    q.append((newX, newY))
        
        return result
        
graph= Graph(6)
graph.add_edge(1,2)
graph.add_edge(1,3)
graph.add_edge(2,3)
graph.add_edge(2,5)
graph.add_edge(3,5)
graph.add_edge(2,4)
graph.add_edge(5,4)


# graph.disply()
# print("DFS \n")
# result=graph.DFS(3)
# print(result)

print("BFS\n")
resultBfs=graph.BFS_Grid(3,3)
print(resultBfs)
