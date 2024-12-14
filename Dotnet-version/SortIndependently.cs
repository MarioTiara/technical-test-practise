
namespace Technical_Test_Practice
{
    public class SortIndependently
    {
        public static List<int> Result (List<int> nums)
        {
            var even=new Queue<int> (nums.Where(p=>p%2==0).Order());
            var odd= new Queue<int>(nums.Where(p=>p%2==1).ToList().OrderDescending());

            var result=new List<int> ();
            while (even.Count>0 || odd.Count>0){
                    var e= even.Dequeue();
                    var o=odd.Dequeue();
                    result.Add(e);
                    result.Add(o);
            }

            return result;


        }
    }
}