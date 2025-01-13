def dfs(grid, x, y):
    result=[]
    rows= len(grid)
    cols=len(grid[0])
    visited=[[False for _ in range (cols) ] for _ in range (rows)]
    
    def recursive_dfs(x, y):
        if x<0 or y<0 or x>=rows or y>=cols or visited[x][y] or grid[x][y]==0:
            return
        
        visited[x][y]=True
        result.append((x,y))
        
        recursive_dfs(x-1, y)
        recursive_dfs(x+1, y)
        recursive_dfs(x, y-1)
        recursive_dfs(x, y+1)
    
    recursive_dfs(x,y)
    return result
        
grid = [
    [1, 1, 0, 0, 0],
    [1, 1, 0, 0, 0],
    [0, 0, 1, 1, 0],
    [0, 0, 0, 1, 1]
]
res= dfs(grid, 0, 0)

print(res)