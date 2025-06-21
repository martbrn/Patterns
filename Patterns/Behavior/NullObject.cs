namespace Patterns.Behavior;

// ======================================================================
// PATRÓN NULL OBJECT (Objeto Nulo)
// ======================================================================
// Evita referencias nulas proporcionando un objeto con comportamiento
// neutro por defecto.

/// <summary>
/// Interfaz común para todos los tipos de descuento
/// </summary>
public interface IDiscount
{
    public double CalculateDiscount(double productCost);
}

/// <summary>
/// Descuento concreto - Para estudiantes
/// </summary>
public class StudentDiscount : IDiscount
{
    public double CalculateDiscount(double productCost)
    {
        return productCost * 0.5;  // 50% de descuento
    }
}

/// <summary>
/// Descuento concreto - Para amigos
/// </summary>
public class FriendDiscount : IDiscount
{
    public double CalculateDiscount(double productCost)
    {
        return productCost * 0.6;  // 40% de descuento
    }
}

/// <summary>
/// NULL OBJECT - Descuento neutro (sin descuento)
/// Evita verificaciones de null y proporciona comportamiento por defecto
/// </summary>
public class NullDiscount : IDiscount
{
    public double CalculateDiscount(double productCost) => 0d;  // Sin descuento
}

/// <summary>
/// Contexto que utiliza los descuentos
/// </summary>
public class Order
{
    private IDiscount _discount;
    private int _productPrice;

    public Order(IDiscount discount, int productPrice)
    {
        _discount = discount;
        _productPrice = productPrice;
    }

    public Order() { }

    /// <summary>
    /// Calcula el descuento sin verificar null gracias al patrón Null Object
    /// </summary>
    public double GetDiscout() => _discount.CalculateDiscount(_productPrice);

    public Order GetOrderByProducyName(string product) => new Order();
}