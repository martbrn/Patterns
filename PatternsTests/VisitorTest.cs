using Patterns.Behavior;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class VisitorTest
{
    [Fact]
    public void CreateVisitor_ShouldBeOk()
    {
        var shapes = new JoinShapes(left: new Circle(3), right: new Square(10));
        var print = new ShapePrint();
        print.Visit(shapes);
        print.ToString().ShouldBe("<figuras>\r\n<circulo>\r\n<radio value=3</circulo>\r\n<cuadrado>\r\n<tamaño value=10</cuadrado>\r\n</figuras>\r\n");
    }
}