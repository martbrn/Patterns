using Patterns.Behavior;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class TemplateMethodTest
{
    [Fact]
    public void CreateTemplateMethod_ShouldBeOk()
    {
        var blanco = new Blanco();
        var result = blanco.Make();
        result.ShouldBe("horneando pan blanco (24 min) ; Colocando ingredientes para el pan blanco ; Cortando el pan Blanco");
        var integral = new Integral();
        result = integral.Make();
        result.ShouldBe("Colocando ingredientes pan integral ; Horneando pan integral (10 min) ; Cortando el pan Integral");
    }
}
