using Patterns.Estructural;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class BridgeTest
{
    [Fact]
    public void CreateBridge_ShouldBeOk()
    {
        var appWindow7 = new Windows7(new NormalDisplay()) { Text = "Aprendiendo Bridge" };
        appWindow7.Display().ShouldBe("Aplicación utilizada desde window 7 \n" + "Aprendiendo Bridge");
        var appWindow10 = new Windows10(new NormalDisplay()) { Text = "Aprendiendo Bridge" };
        appWindow10.Display().ShouldBe("Aplicación utilizada desde window 10 \n" + "Aprendiendo Bridge");

        var appWindowReverse7 = new Windows7(new ReverseDisplay()) { Text = "Aprendiendo Bridge" };
        appWindowReverse7.Display().ShouldBe("egdirB odneidnerpA\n 7 wodniw edsed adazilitu nóicacilpA");
        var appWindowReverse10 = new Windows10(new ReverseDisplay()) { Text = "Aprendiendo Bridge" };
        appWindowReverse10.Display().ShouldBe("egdirB odneidnerpA\n 01 wodniw edsed adazilitu nóicacilpA");
    }
}
