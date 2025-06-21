using Patterns.Creational.FluentBuilder;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class FluentBuilderTest
{
    [Fact]
    public void CreateFluentBuilder_ShouldBeOk()
    {
        var car = CarBuilder
            .CreateNew()
            .AddName("Ford")
            .AddModel("2012")
            .Build();

        car.ToString().ShouldBe($"Mi automovil es Ford, Modelo: 2012");
    }
}