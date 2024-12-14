using Technical_Test_Practice;


public class RandomizedSet
{
    private Dictionary<int, int> dict;
    private List<int> list;
    private Random rand;

    public RandomizedSet()
    {
        dict= new Dictionary<int, int>();
        list= new List<int>();
        rand= new Random();
    }

    public bool Insert(int val)
    {
        var res= !dict.ContainsKey(val);
        if (res)
        {
            list.Add(val);
            dict.Add(val, list.Count-1);
        }
        return res;
    }

    public bool Remove(int val)
    {
        var res=dict.ContainsKey(val);
        if (res)
        {
            var index=dict[val];
            dict.Remove(val);

            list[index]=list.Last();
            list.RemoveAt(list.Count-1);
        }

        return res;
    }

    public int GetRandom()
    {
        var index= rand.Next(list.Count);
        return list[index];
    }


}