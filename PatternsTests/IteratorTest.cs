using Patterns.Behavior;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class IteratorTest
{
    [Fact]
    public void CreateIterator_ShouldBeOk()
    {
        var breakFastMenu = new BreakfastMenuCollection();
        var breakfastMenuIterator = breakFastMenu.CreateIterator();

        while (breakfastMenuIterator.HasNext())
        {
            var menu = breakfastMenuIterator.Next();
            menu.Name.ShouldNotBeEmpty();
            menu.Description.ShouldNotBeEmpty();
            menu.Price.ShouldBeGreaterThan(0);
        }
    }
}