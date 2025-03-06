
def reverse(s:str)->str:
    arr=list(s)
    l=0
    r=len(arr)-1
    vows={'a','e','i','o','u'}
    while l<=r:
        if arr[l].lower() in vows and arr[r].lower() in vows:
            temp=arr[l]
            arr[l]=arr[r]
            arr[r]=temp
            l+=1
            r-=1
        elif arr[l].lower() not in vows and arr[r].lower() in vows:
            l+=1
        
        elif arr[l].lower() in vows and arr[r].lower() not in vows:
            r-=1
        
        else:
            r-=1
            l+=1
    
    
    return "".join(arr)


s="IceCreAm"
res=reverse(s)

print(res)

print("aaa")
