using Patterns.Estructural;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class FacadeTest
{
    [Fact]
    public void CreateAdapter_ShouldBeOk()
    {
        var homeController = new HomeController();
        homeController.TurnOn().Count.ShouldBe(3);
        homeController.TurnOff().Count.ShouldBe(3);

        var turnOnList = homeController.TurnOn();
        var turnOffList = homeController.TurnOff();
        turnOnList[0].ShouldBe("Wifi is on");
        turnOnList[1].ShouldBe("Aire acondicionado is on");
        turnOnList[2].ShouldBe("Luz is on");
        turnOffList[0].ShouldBe("Wifi is off");
        turnOffList[1].ShouldBe("Aire acondicionado is off");
        turnOffList[2].ShouldBe("Luz is off");
    }
}
