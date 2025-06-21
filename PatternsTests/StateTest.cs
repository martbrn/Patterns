using Patterns.Behavior;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class StateTest
{
    [Fact]
    public void ShouldChangeBehaviorWithState_ShouldBeOk()
    {
        var context = new Context(new OffState());
        context.Request().ShouldBe("System Off");
        context.SetState(new OnState());
        context.Request().ShouldBe("System On");
    }
}