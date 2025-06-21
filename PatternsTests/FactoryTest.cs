using Patterns.Creational.Factory;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class FactoryTest
{
    [Fact]
    public void CreateFactory_ShouldBeOk()
    {
        var user = User.Factory.CreateWithDefaultCountry("Rodrigo", "rodrigo@gmail.com");
        user.Country.ShouldBe("Chile");
        user.Name.ShouldBe("Rodrigo");
        user.Email.ShouldBe("rodrigo@gmail.com");
    }

    [Fact]
    public void CreateFactory_WithReflection_ShouldBeOk()
    {
        var nyStore = new NYPizzaStore();
        var pizza = nyStore.OrderPizza(TypeOfPizza.Pepperoni);
        pizza.Name.ShouldBe("Pepperoni");
    }

    [Fact]
    public void CreateFactory_Student_ShouldBeOk()
    {
        var student = Student.StudentFactory.Create("Martin");
        student.Name.ShouldBe("Martin");
        student.Id.ShouldBe(1);
    }
}
