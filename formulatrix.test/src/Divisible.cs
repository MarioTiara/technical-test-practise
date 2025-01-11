using System.Text;

namespace Formulatrix.comptency;

public class Divisible
{
    private readonly Dictionary<int, string> _rules;


    public Divisible()
    {
        _rules = new Dictionary<int, string>{
            { 3, "foo" },
            { 5, "bar" }
        };
    }

    public string GetValue(int x)
    {
        var result = new StringBuilder();
        foreach (var (key, value) in _rules)
        {
            if (x % key == 0)
            {
                result.Append(value);
            }
        }

        return string.IsNullOrEmpty(result.ToString()) ? x.ToString() : result.ToString();
    }

    public void PrintRange(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            var value = this.GetValue(i);
            if (i==n)
            {
                Console.Write(value + "");
            }
            else
            {
                Console.Write(value+", ");
            }
            
        }
    }

    
    public IDictionary<int, string> Rules=> _rules.AsReadOnly();
    
    public void AddRule(int input, string output)
    {
        if (_rules.ContainsKey(input))
        {
            throw new ArgumentException("Input is already in rules.");
        }
        _rules.Add(input, output);
    }


}
