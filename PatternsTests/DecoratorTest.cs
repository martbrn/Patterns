using Patterns.Estructural;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class DecoratorTest
{
    [Fact]
    public void CreateDecorator_ShouldBeOk()
    {
        var espressoWithMilkAndChocolate = new MilkDecorator(new ChocolateDecorator(new Espresso()));
        espressoWithMilkAndChocolate.GetDescription().ShouldBe("Espresso simple Chocolate Leche");
        espressoWithMilkAndChocolate.GetCost().ToString().ShouldBe("3,95");
    }
}
