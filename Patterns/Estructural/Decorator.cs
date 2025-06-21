namespace Patterns.Estructural;

// ======================================================================
// PATRÓN DECORATOR (DECORADOR)
// ======================================================================
/// Permite añadir funcionalidades a objetos dinámicamente sin alterar su estructura.
/// Proporciona una alternativa flexible a la herencia para extender funcionalidad.
/// Los decoradores tienen la misma interfaz que los objetos que envuelven.


/// <summary>
/// Interfaz común (Component) que define las operaciones básicas.
/// Tanto los objetos concretos como los decoradores implementan esta interfaz.
/// Permite tratar uniformemente objetos decorados y no decorados.
/// </summary>
public interface ICoffe
{
    string GetDescription();
    double GetCost();
}

/// <summary>
/// Clase base abstracta para todos los decoradores (Decorator).
/// Implementa la interfaz del componente y contiene una referencia al componente que decora.
/// Define la estructura común para todos los decoradores concretos.
/// </summary>
public abstract class CondimentDecorator : ICoffe
{
    /// <summary>
    /// Referencia al objeto que está siendo decorado.
    /// Puede ser un objeto concreto o otro decorador (permite anidar decoradores).
    /// </summary>
    ICoffe _coffe;

    /// <summary>
    /// Precio adicional que añade este decorador.
    /// </summary>
    protected double _price = 0.0;

    /// <summary>
    /// Nombre del condimento que añade este decorador.
    /// </summary>
    protected string _name = string.Empty;

    protected CondimentDecorator(ICoffe coffe)
    {
        _coffe = coffe;
    }

    /// <summary>
    /// Calcula el costo total delegando al objeto decorado y añadiendo el costo propio.
    /// Implementa el comportamiento recursivo típico del patrón Decorator.
    /// </summary>
    public double GetCost()
    {
        return _coffe.GetCost() + _price; // Delega + añade funcionalidad
    }

    /// <summary>
    /// Construye la descripción completa delegando al objeto decorado y añadiendo la propia.
    /// Demuestra cómo se pueden combinar comportamientos de múltiples decoradores.
    /// </summary>
    public string GetDescription()
    {
        return $"{_coffe.GetDescription()} {_name}"; // Delega + añade funcionalidad
    }
}

/// <summary>
/// Decorador concreto (ConcreteDecorator) que añade leche al café.
/// Extiende la funcionalidad básica del café añadiendo un ingrediente específico.
/// </summary>
public class MilkDecorator : CondimentDecorator
{
    public MilkDecorator(ICoffe coffe) : base(coffe)
    {
        _name = "Leche";
        _price = 0.25;
    }
}

/// <summary>
/// Otro decorador concreto que añade chocolate al café.
/// Demuestra cómo se pueden crear múltiples decoradores independientes.
/// </summary>
public class ChocolateDecorator : CondimentDecorator
{
    public ChocolateDecorator(ICoffe coffe) : base(coffe)
    {
        _name = "Chocolate";
        _price = 0.45;
    }
}

/// <summary>
/// Componente concreto (ConcreteComponent) que representa un café filtrado básico.
/// Implementa la funcionalidad base sin decoraciones adicionales.
/// Sirve como objeto base que puede ser decorado.
/// </summary>
public class Filtered : ICoffe
{
    public string GetDescription()
    {
        return "Filtrado simple";
    }

    public double GetCost()
    {
        return 5.65;
    }
}

/// <summary>
/// Otro componente concreto que representa un espresso básico.
/// Proporciona una implementación alternativa del componente base.
/// </summary>
public class Espresso : ICoffe
{
    public string GetDescription()
    {
        return "Espresso simple";
    }

    public double GetCost()
    {
        return 3.25;
    }
}