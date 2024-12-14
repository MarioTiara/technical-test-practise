using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Technical_Test_Practice.Arry_Problems
{
    public class LC238_ProductOfArrayEceptSelf
    {
        public static int[] ProductExceptSelf(int[] nums)
        {
            int n= nums.Length;

            int[] leftProducts = new int[n];
            int [] rightProducts= new int[n];
            int [] result = new int[n];

            //Compute left products
            int leftProduct=1;
            for (int i=0; i<n; i++)
            {
                leftProducts[i]=leftProduct;
                leftProduct*=nums[i];
            }

            int rightProduct=1;
            for (int i=n-1; i>=0; i--)
            {
                rightProducts[i]= rightProduct;
                rightProduct*=nums[i];
            }

            for (int i=0; i<n; i++)
            {
                result[i]= leftProducts[i]*rightProducts[i];
            }

            return result;
        }
    }
}