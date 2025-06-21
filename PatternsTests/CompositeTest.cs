using Patterns.Estructural;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class CompositeTest
{
    [Fact]
    public void CreateComposite_ShouldBeOk()
    {
        var gamingKit = new CompositeProduct("Computador gamer básico");
        gamingKit.Add(new SimpleProduct("Ram 16 gb", 7000));
        gamingKit.Add(new SimpleProduct("Intel core 7", 17000));
        gamingKit.Add(new SimpleProduct("nVidia gtx 1050", 85000));
        gamingKit.Add(new SimpleProduct("Teclado Dell", 300));
        gamingKit.Add(new SimpleProduct("Mouse Dell", 300));
        gamingKit.Add(new SimpleProduct("Torre hp", 3000));
        gamingKit.Add(new SimpleProduct("Led Lg", 4000));
        gamingKit.GetPrice().ShouldBe("El precio de Computador gamer básico es 116.600,00");
    }
}
