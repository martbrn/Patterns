// =============================================
// FACTORY METHOD PATTERN - Abstract Factory
// =============================================
// Propósito: Crear familias de objetos relacionados sin especificar sus clases concretas
// Cuándo usar: Cuando necesitas crear objetos que varían según el contexto o ubicación

using static System.Console;

namespace Patterns.Creational.Factory;

/// <summary>
/// Clase base abstracta para todas las pizzas
/// Define la interfaz común y el proceso de preparación
/// </summary>
public abstract class Pizza
{
    public string Name { get; set; } = string.Empty;
    protected string Dough = string.Empty;
    protected string Sauce = string.Empty;
    protected List<string> Toppings = new();

    /// <summary>
    /// Método template que define los pasos de preparación
    /// </summary>
    public void Prepare()
    {
        WriteLine($"Prepararando: {Name}");
        WriteLine($"Colocando masa: {Dough}");
        WriteLine($"Agregando salsa: {Sauce}");
        WriteLine($"Agregando Capas: {string.Join(",", Toppings)}");
    }

    public void Bake() => WriteLine($"Cocinar por 20 min");
    public void Cut() => WriteLine($"Pizza fue cortada en partes iguales");
    public void Box() => WriteLine($"Pizza colocada en caja oficial");
}

/// <summary>
/// Clase base abstracta para tiendas de pizza
/// Implementa el patrón Factory Method
/// </summary>
public abstract class PizzaStore
{
    /// <summary>
    /// Factory Method abstracto - cada tienda implementa su propia versión
    /// Este es el núcleo del patrón Factory Method
    /// </summary>
    public abstract Pizza CreatePizza(TypeOfPizza type);

    /// <summary>
    /// Método template que define el proceso completo de pedido
    /// Usa el factory method para crear la pizza específica
    /// </summary>
    public Pizza OrderPizza(TypeOfPizza type)
    {
        var pizza = CreatePizza(type); // Llamada al factory method
        pizza.Prepare();
        pizza.Cut();
        pizza.Box();
        return pizza;
    }
}

/// <summary>
/// Enumeración que define los tipos de pizza disponibles
/// </summary>
public enum TypeOfPizza
{
    Pepperoni,
    Neapolitan,
    California
}

/// <summary>
/// Implementación concreta del factory para pizzas estilo Nueva York
/// Usa reflexión para crear instancias dinámicamente
/// </summary>
public class NYPizzaStore : PizzaStore
{
    /// <summary>
    /// Implementación del factory method para pizzas NY
    /// Utiliza reflexión para crear instancias basadas en convención de nombres
    /// </summary>
    public override Pizza CreatePizza(TypeOfPizza type)
    {
        // Construye el nombre de la clase basado en convención
        var className = $"Patterns.Creational.Factory.NY{Enum.GetName(typeof(TypeOfPizza), type)}Pizza";
        var pizzaType = Type.GetType(className);

        if (pizzaType == null)
            throw new InvalidOperationException($"No se pudo encontrar el tipo '{className}'");

        return (Pizza)Activator.CreateInstance(pizzaType)!;
    }
}

/// <summary>
/// Implementación concreta del factory para pizzas estilo Florida
/// Similar a NYPizzaStore pero crea pizzas con estilo de Florida
/// </summary>
public class FLPizzaStore : PizzaStore
{
    /// <summary>
    /// Implementación del factory method para pizzas FL
    /// </summary>
    public override Pizza CreatePizza(TypeOfPizza type)
    {
        // Construye el nombre de la clase basado en convención
        var className = $"Patterns.Creational.Factory.FL{Enum.GetName(typeof(TypeOfPizza), type)}Pizza";
        var pizzaType = Type.GetType(className);

        if (pizzaType == null)
            throw new InvalidOperationException($"No se pudo encontrar el tipo '{className}'");

        return (Pizza)Activator.CreateInstance(pizzaType)!;
    }
}

#region NewYork Pizza Implementations
/// <summary>
/// Implementación concreta de pizza Pepperoni estilo Nueva York
/// </summary>
internal class NYPepperoniPizza : Pizza
{
    public NYPepperoniPizza()
    {
        Name = "Pepperoni";
        Dough = "delgada";
        Sauce = "Salsa de tomates";
        Toppings.Add("Quesso mozarella");
    }
}

/// <summary>
/// Implementación concreta de pizza California estilo Nueva York
/// </summary>
internal class NYCaliforniaPizza : Pizza
{
    public NYCaliforniaPizza()
    {
        Name = "caifornia";
        Dough = "delgada";
        Sauce = "Salsa de tomates";
        Toppings.Add("Quesso mozarella");
    }
}

/// <summary>
/// Implementación concreta de pizza Napolitana estilo Nueva York
/// </summary>
internal class NYNeapolitanPizza : Pizza
{
    public NYNeapolitanPizza()
    {
        Name = "Napolitana";
        Dough = "delgada";
        Sauce = "Salsa de tomates";
        Toppings.Add("Quesso mozarella");
    }
}
#endregion

#region Florida Pizza Implementations
/// <summary>
/// Implementación concreta de pizza Pepperoni estilo Florida
/// </summary>
internal class FLPepperoniPizza : Pizza
{
    public FLPepperoniPizza()
    {
        Name = "Pepperoni";
        Dough = "delgada";
        Sauce = "Salsa de tomates";
        Toppings.Add("Quesso mozarella");
    }
}

/// <summary>
/// Implementación concreta de pizza California estilo Florida
/// </summary>
internal class FLCaliforniaPizza : Pizza
{
    public FLCaliforniaPizza()
    {
        Name = "caifornia";
        Dough = "delgada";
        Sauce = "Salsa de tomates";
        Toppings.Add("Quesso mozarella");
    }
}

/// <summary>
/// Implementación concreta de pizza Napolitana estilo Florida
/// </summary>
internal class FLNeapolitanPizza : Pizza
{
    public FLNeapolitanPizza()
    {
        Name = "Napolitana";
        Dough = "delgada";
        Sauce = "Salsa de tomates";
        Toppings.Add("Quesso mozarella");
    }
}
#endregion