using Patterns.Estructural;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class FlyweightTest
{
    [Fact]
    public void ShouldShareFlyweightInstances_ShouldBeOk()
    {
        var factory = new CharacterFactory();
        var a1 = factory.GetCharacter('a');
        var a2 = factory.GetCharacter('a');
        a1.ShouldBe(a2);
        factory.Count.ShouldBe(1);
    }
}
