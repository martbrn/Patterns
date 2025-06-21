using Patterns.Behavior;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class StrategyTest
{
    [Fact]
    public void CreateStategy_ShouldBeOk()
    {
        var tp = new TextProcessor(OutputFormat.NumberList);
        tp.AppendList(["c#", "Java", "Phyton"]);
        tp.sb.ToString().ShouldBe("1 c#\r\n2 Java\r\n3 Phyton\r\n");
        tp = new TextProcessor(OutputFormat.Html);
        tp.AppendList(["c#", "Java", "Phyton"]);
        tp.sb.ToString().ShouldBe("<ul>\r\n <li>c#</li>\r\n <li>Java</li>\r\n <li>Phyton</li>\r\n</ul>\r\n");
    }
}
