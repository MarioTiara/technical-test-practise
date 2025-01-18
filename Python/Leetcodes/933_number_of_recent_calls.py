from collections import deque


class RecentCounter:

    def __init__(self):
        self.que=deque()

    def ping(self, t: int) -> int:
        lower_bound=t-3000
        self.que.append(t)
        
        while len(self.que)>0:
            if self.que[0]<lower_bound:
                self.que.popleft()
            else:
                break
        
        return len(self.que)


call=RecentCounter()

print(call.ping(1))
print(call.ping(100))
print(call.ping(3001))
print(call.ping(3002))
print(call.ping(3004))
