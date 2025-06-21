using Patterns.Behavior;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class InterpreterTest
{
    [Fact]
    public void CreateInterpreter_ShouldBeOk()
    {
        var input = "2 1 5 + *";
        var expressionParser = new ExpressionParser();
        var result = expressionParser.Parse(input);
        result.ShouldBe(12);
    }
}