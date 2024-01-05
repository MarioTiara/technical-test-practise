using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_Test_Practice
{
    public class ArrayLeftRotation
    {
         public static List<int> rotLeft(List<int> a, int d)
    {
        int [] temp = new int [d];
        
        //Save element which will be out on the right side
        for(int i=0; i<d; i++){
            temp[i]=a[i];
        }
        
        //Switch left element to the left
        int right=d;
        int left=0;
        while(right<a.Count){
            a[left]=a[right];
            left++;
            right++;
        }
        
        //Copy temp element to the righ side
        int uppBound= a.Count-1-d+1;
        int temPointer=0;
        for (int i= uppBound; i<a.Count; i++){
            a[i]=temp[temPointer];
            temPointer++;
        }
        
        return a;
        
        
        
    }
    }
}