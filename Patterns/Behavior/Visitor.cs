namespace Patterns.Behavior;

// ======================================================================
// PATRÓN VISITOR (Visitante)
// ======================================================================
// Permite definir nuevas operaciones sin cambiar las clases de los elementos
// sobre los que opera.

using System.Text;

/// <summary>
/// Interfaz del Visitor - Define visitas para cada tipo de elemento
/// </summary>
public interface IShapeVisitor
{
    void Visit(Square square);
    void Visit(Circle circle);
    void Visit(JoinShapes joinShapes);
}

/// <summary>
/// Clase abstracta Element - Define la operación Accept
/// </summary>
public abstract class Shape
{
    public abstract void Accept(IShapeVisitor visitor);
}

/// <summary>
/// Elemento concreto - Círculo
/// </summary>
public class Circle : Shape
{
    public int Radius { get; }

    public Circle(int radius)
    {
        Radius = radius;
    }

    public override void Accept(IShapeVisitor visitor)
    {
        visitor.Visit(this);  // Double dispatch
    }
}

/// <summary>
/// Elemento concreto - Cuadrado
/// </summary>
public class Square : Shape
{
    public int Size { get; }

    public Square(int size)
    {
        Size = size;
    }

    public override void Accept(IShapeVisitor visitor)
    {
        visitor.Visit(this);  // Double dispatch
    }
}

/// <summary>
/// Elemento compuesto - Figuras unidas
/// </summary>
public class JoinShapes : Shape
{
    public Shape Left { get; }
    public Shape Right { get; }

    public JoinShapes(Shape left, Shape right)
    {
        Left = left;
        Right = right;
    }

    public override void Accept(IShapeVisitor visitor)
    {
        visitor.Visit(this);  // Double dispatch
    }
}

/// <summary>
/// Visitor concreto - Impresión de formas en XML
/// </summary>
public class ShapePrint : IShapeVisitor
{
    StringBuilder sb = new StringBuilder();

    public void Visit(Square square)
    {
        sb.AppendLine("<cuadrado>");
        sb.Append($"<tamaño value={square.Size}");
        sb.AppendLine("</cuadrado>");
    }

    public void Visit(Circle circle)
    {
        sb.AppendLine("<circulo>");
        sb.Append($"<radio value={circle.Radius}");
        sb.AppendLine("</circulo>");
    }

    public void Visit(JoinShapes joinShapes)
    {
        sb.AppendLine("<figuras>");
        joinShapes.Left.Accept(this);   // Visita recursiva
        joinShapes.Right.Accept(this);  // Visita recursiva
        sb.AppendLine("</figuras>");
    }

    public override string ToString() => sb.ToString();
}