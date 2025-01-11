using System.Text.Json;
using HackerRank;
using Matrix;
using Technical_Test_Practice;


public class DoublyLinkedListNode
{
    public int data { get; set; }
    public DoublyLinkedListNode next { get; set; }
    public DoublyLinkedListNode prev { get; set; }

    public DoublyLinkedListNode(int data)
    {
        this.data = data;
    }
}

internal class Program
{

    private static void Main(string[] args)
    {
        // char[][] grid = new char[][]
        // {
        //     new char[] { '1', '1', '1', '1', '0' },
        //     new char[] { '1', '1', '0', '1', '0' },
        //     new char[] { '1', '1', '0', '0', '0' },
        //     new char[] { '0', '0', '0', '0', '0' }
        // };
        char[][] grid = new char[][]
        {
            new char[] { '1', '1', '0', '0', '0' },
            new char[] { '1', '1', '0', '0', '0' },
            new char[] { '0', '0', '1', '0', '0' },
            new char[] { '0', '0', '0', '1', '1' }
        };

        var result = NumberOfIsland.NumsIsLands(grid);
        Console.WriteLine(result);

    }

    private static void PrintPrime(int n)
    {
        var isPrime = new bool[n + 1];
        for (int i = 0; i < n; i++)
        {
            isPrime[i] = true;
        }

        isPrime[0] = isPrime[1] = false;

        for (int i = 0; i * i <= n; i++)
        {
            Console.WriteLine($"i:{i}-{JsonSerializer.Serialize(isPrime)}");
            if (isPrime[i])
            {
                for (int j = i * i; j <= n; j += i)
                {
                    isPrime[j] = false;

                }

            }
        }

        for (int i = 0; i <= n; i++)
        {
            if (isPrime[i])
            {
                Console.Write($"{i} ");
            }
        }
    }

    static bool IsPrime2(int n)
    {
        if (n < 2)
            return false;
        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }
    static bool IsPrimer(int number)
    {
        var sqrt = Math.Sqrt(number);
        for (int i = 2; i <= sqrt; i++)
        {
            if (number % i == 0)
            {
                return false;

            }
        }

        return true;
    }

    public class MyStack
    {
        private List<int> _list;
        private int _top;
        public MyStack()
        {
            _list = new List<int>();
            _top = -1;
        }

        public void Push(int x)
        {
            _top++;
            _list[_top] = x;
        }

        public int Pop()
        {
            return _list[_top--];
        }

        public int Top()
        {
            return _list[_top];
        }

        public bool Empty()
        {
            return _top == -1;
        }
    }

    public static int EraseOverlapIntervals(int[][] intervals)
    {
        //overlaping = [0]<[0] && [1]<[1]
        var len = intervals.Length;
        intervals = intervals.OrderBy(p => p[0]).ThenBy(p => p[1]).ToArray();
        var overLapCount = 0;
        var nonOverlap = new Stack<int[]>();
        nonOverlap.Push(intervals[0]);
        int i = 1;
        while (i < len)
        {
            var lastNonOverlap = nonOverlap.Peek();
            if (lastNonOverlap[1] > intervals[i][0])
            {
                overLapCount++;
            }
            else
            {
                nonOverlap.Push(intervals[i]);
            }
            i++;
        }

        return overLapCount;

    }


    public static int MinSubArrayLen(int target, int[] nums)
    {
        int currentSum = 0;
        int l = 0;
        int minSize = int.MaxValue;
        for (int r = 0; r < nums.Length; r++)
        {
            currentSum += nums[r];
            while (currentSum >= target)
            {
                minSize = Math.Min(minSize, (r - l + 1));

                currentSum -= nums[l];
                l++;
            }
        }

        return minSize != int.MaxValue ? minSize : 0;
    }


    public static int[][] Merge(int[][] intervals)
    {
        var merges = new List<int[]>();
        intervals = intervals.OrderBy(p => p[0]).ToArray();
        var intervalLength = intervals.Length;
        int i = 0;
        while (i < intervalLength)
        {
            var j = i;
            var merged = intervals[i];
            while (j < intervalLength && intervals[j][0] <= merged[1])
            {
                merged = new int[] { merged[0], intervals[j][1] };
                j++;
                i = j;
            }
            merges.Add(merged);
        }

        return merges.ToArray();
    }

    private static string MinWindow(string s, string t)
    {
        if (s.Length < t.Length)
            return "";
        var tTable = new Dictionary<char, int>();
        foreach (var c in t)
        {
            if (!tTable.ContainsKey(c))
            {
                tTable.Add(c, 0);
            }
            tTable[c]++;
        }

        var sTable = new Dictionary<char, int>();
        var mindwindow = new int[2] { 0, 0 };
        var sLength = s.Length;
        int l = 0, r = 1;
        int minLength = int.MaxValue;
        sTable.Add(s[l], 1);
        while (l < r)
        {
            //while sTable is not contains all char with same value with tTable;
            while (r < sLength && !IsValidSubstring(tTable, sTable))
            {
                if (!sTable.ContainsKey(s[r]))
                {
                    sTable.Add(s[r], 0);
                }
                sTable[s[r]]++;
                r++;
            }
            var length = r - l;
            if (IsValidSubstring(tTable, sTable))
            {
                minLength = Math.Min(minLength, length);
                mindwindow[0] = l;
                mindwindow[1] = r;
            }
            sTable[s[l]]--;
            l++;
        }
        return s.Substring(mindwindow[0], mindwindow[1] - mindwindow[0]);
    }

    private static bool IsValidSubstring(Dictionary<char, int> tTable, Dictionary<char, int> sTable)
    {
        foreach (var (k, v) in tTable)
        {
            if (!sTable.ContainsKey(k))
                return false;
            if (sTable.ContainsKey(k) && sTable[k] < v)
                return false;
        }
        return true;
    }

    public static int CountSubstrings(string s)
    {
        var sLength = s.Length;
        int count = 0;
        for (int i = 0; i < sLength; i++)
        {
            int l = i;
            int r = i;

            while (l == 0 && r < sLength && s[l] == s[r])
            {
                count++;
                r++;
            }

            while (l > 0 && r < sLength && s[l] == s[r])
            {
                count++;
                l--;
                r++;
            }
        }

        return count;
    }


}