using Patterns.Estructural;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class ProxyTest
{
    [Fact]
    public void CreateProxy_ShouldBeFalseOk()
    {
        var car = new CarProxy(new Driver(17, true));
        var result = car.Drive();
        result.ShouldBe(false);
    }

    [Fact]
    public void CreateProxy_ShouldBeTrueOk()
    {
        var car = new CarProxy(new Driver(20, true));
        var result = car.Drive();
        result.ShouldBe(true);
    }
}
