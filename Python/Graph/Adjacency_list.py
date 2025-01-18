from collections import deque
class Undirected_Graph:
    def __init__(self, vertices):
        self.adjlist=[[] for _ in range (vertices)]
    def add_edge(self,i,j):
        self.adjlist[i].append(j)
        self.adjlist[j].append(i)
        
    def display(self):
        print (self.adjlist)
    
    def DFS(self, start):
        visited=[False] * len(self.adjlist)
        result=[]
        
        def dfs_recursive(v):
            if  visited[v]:
                return
            
            visited[v]=True
            result.append(v)
            for n in self.adjlist[v]:
                dfs_recursive(n)
        
        dfs_recursive(start)
        return result
    
    def has_path(self, src, dst):
        visited=[False]*len(self.adjlist)
        
        def dfs_hash_path(src, dst):
            if  src==dst:
                return True
            visited[src]=True
            
            for n in self.adjlist[src]:
                if not visited[n] and dfs_hash_path(n, dst):
                    return True
            
            return False
        return dfs_hash_path(src, dst)

    
    
    def hash_path_with_bfs(self, src, dst):
        visited=[False] * len (self.adjlist)
        que= deque()
        que.append(src)
        
        while len (que)>0:
            v= que.popleft()
            if v==dst: return True
            for n in self.adjlist[src]:
                if not visited[n]:
                    visited[n]=True
                    que.append(n)
        
        return False
                
            
    def BFS (self, start):
        visited=[False] * len(self.adjlist)
        result=[]
        que= deque()
        que.append(start)
        visited[start]=True
        
        while(len(que)>0):
            v= que.popleft()
            result.append(v)
            for n in self.adjlist[v]:
                if not visited[n]:
                    visited[n]=True
                    que.append(n)
        return result
    
    def connected_node(self):
        visited=[False] * len (self.adjlist)
        def bfs(start):
            queu= deque()
            queu.append(start)
            visited[start]=True
            while len (queu)>0:
                v=queu.popleft()
                for n in self.adjlist[v]:
                    if not visited[n]:
                        visited[n]=True
                        queu.append(n)
        
        count=0
        for i in range(len(self.adjlist)):
            if not visited[i]:
                bfs(i)
                count+=1
        
        return count
                
        

class Directed_Grpah:
    def __init__(self, vertices:int):
        self.list=[[] for _ in range (vertices)]
    
    def add__neighbor(self, v, n):
        self.list[v].append(n)
    
    def display(self):
        print (self.list)
    
    def BFS (self, start):
        result=[]
        que= deque()
        que.append(start)
        
        while len (que)>0 :
            v= que.popleft()
            result.append(v)
            for n in self.list[v]:
                que.append(n)
                
        return result
    
    def DFS(self, start):
        result=[]
        
        def recursive_dfs(v):
            
            result.append(v)
            for n in self.list[v]:
                recursive_dfs(n)
            
        
        recursive_dfs(start)
        return result

    def has_path(self,src, dest)-> bool:
        if src==dest:
            return True
        
        for n in self.list[src]:
            if self.has_path(n, dest):
                return True

        return False
    
    def bfs_has_path(self, src, dest):
        que= deque()
        que.append(src)
        
        while len(que)>0:
            v= que.popleft()
            
            if v==dest: return True
            for n in self.list[v]:
                que.append(n)
        
        return False

# gr= Directed_Grpah(6)

# gr.add__neighbor(0,1)
# gr.add__neighbor(0,3)
# gr.add__neighbor(1,2)
# gr.add__neighbor(3,2)
# gr.add__neighbor(4,3)
# gr.add__neighbor(3,5)

# gr.display()
# bfs=gr.BFS(0)
# print(f"bfs: {bfs}")  

# dfs=gr.DFS(3)
# print(f"dfs: {dfs}")  

# print(f" has path: {gr.has_path(3,2)}")
# print(f" bfs has path: {gr.bfs_has_path(5,0)}")


undr_graph= Undirected_Graph(10)
undr_graph.add_edge(0,1)
undr_graph.add_edge(3,4)
undr_graph.add_edge(5,4)
undr_graph.add_edge(6,4)
undr_graph.add_edge(7,4)
undr_graph.add_edge(8,9)
undr_graph.display()

connected_node= undr_graph.connected_node()
print(connected_node)
# print(f" has path: {undr_graph.has_path(0,7)}")
# print(f"bfs has path: {undr_graph.has_path(0,5)}")
  