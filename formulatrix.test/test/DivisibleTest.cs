namespace Formulatrix.comptency.test;

public class DivisibleTest
{
    [Fact]
    public void AddRule_ShouldAddRuleWhenRulesNotContainsInputKey()
    {
        //Arrange
        var divisible= new Divisible();
        var output="jazz";

        //Act
        divisible.AddRule(7, output);

        //Assert
        var rules=divisible.Rules;
        Assert.True(rules.ContainsKey(7));
        Assert.Equal(output, rules[7]);
         
    }
    [Fact]
    public void AddRule_ShouldThrowErrorWhenRulesContainsInputKey()
    {
        //Arrange
        var divisible= new Divisible();
        divisible.AddRule(7,"foo");

        //Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>divisible.AddRule(7,"foo"));
        
         //Verify the exception message
         Assert.Equal("Input is already in rules.", exception.Message);
    }

    [Fact]
    public void PrintRange_ShouldPrintCorrentOutputString()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var divisible = new Divisible();


        //Act
        divisible.PrintRange(15);
        var output = stringWriter.ToString().Trim();
        
        //Assert
        var expectedOutput = "1, 2, foo, 4, bar, foo, 7, 8, foo, bar, 11, foo, 13, 14, foobar";
        Assert.Equal(expectedOutput, output);

    }

    [Theory]
    [InlineData(21, "foojazz")]
    [InlineData(35, "barjazz")]
    [InlineData(105, "foobarjazz")]
    [InlineData(16, "baz")]
    [InlineData(9, "foohuzz")]
    [InlineData(36, "foobazhuzz")]
    public void GetValue_ShouldReturnCorrentValue(int input, string value)
    {
        //Arrange
        var divisible = new Divisible();
        divisible.AddRule(7, "jazz");
        divisible.AddRule(4, "baz");
        divisible.AddRule(9, "huzz");

        //Act
        var result = divisible.GetValue(input);

        Assert.Equal(value, result);
    }


}