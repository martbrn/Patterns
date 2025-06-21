using Patterns.Behavior;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class ChainResponsibilityTest
{
    [Fact]
    public void CreateChainResponsibility_ShouldBeOk()
    {
        var low = new LowLevelHandler();
        var high = new HighLevelHandler();
        low.SetNext(high);
        var result = low.Handle("high");
        result.ShouldBe("Handled by HighLevel");
    }
}