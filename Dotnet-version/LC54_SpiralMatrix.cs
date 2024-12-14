using System.Text.Json;
using System.Text.Json.Nodes;

namespace Technical_Test_Practice;

public class SpiralMatrix
{
    public static List<int> SpiralOrder(int[][] matrix)
    {
        var result = new List<int>();

        int top=0, bottom= matrix.Length-1;
        int left=0, right=matrix[0].Length-1;

        while (top<=bottom && left<=right){
            //traverse from left to the right-> shrink right boundaries
            for (int i=left; i<=right; i++){
                result.Add(matrix[top][i]);
            }
            top++;
            //traverse from top to buttom --> shring the top boundaries
            for (int i=top; i<=bottom; i++){
                result.Add(matrix[i][right]);
            }
            right--;

             //traverse from right to the left
             if (top<=bottom){
                for (int i=right; i>=left; i--){
                    result.Add(matrix[bottom][i]);
                }
                bottom--;
             }
            
            //traverser from buttom to the top
             if (left<=right){
                for (int i=bottom; i>=top; i--){
                    result.Add(matrix[i][left]);
                }
                left++;
             }

        }

        return result;


    }
}