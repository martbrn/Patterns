using Patterns.Behavior;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class MediatorTest
{
    [Fact]
    public void CreateMediator_ShouldBeOk()
    {
        var mediator = new Mediator();
        var flight1 = new Flight(mediator);
        var runway = new Runway(mediator);
        mediator.RegisterFlight(flight1);
        mediator.RegisterRunway(runway);
        flight1.Land().ShouldBe("Esperando disponibilidad");
        runway.Land().ShouldBe("Permiso para aterrizar");
        flight1.Land().ShouldBe("Se puede aterrizar");
    }
}