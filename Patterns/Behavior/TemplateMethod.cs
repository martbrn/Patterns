namespace Patterns.Behavior;

// ======================================================================
// PATRÓN TEMPLATE METHOD (Método Plantilla)
// ======================================================================
// Define el esqueleto de un algoritmo en una operación, permitiendo que
// las subclases redefinan ciertos pasos sin cambiar la estructura.

/// <summary>
/// Clase abstracta que define el Template Method para hacer pan
/// </summary>
public abstract class Bread
{
    // Pasos abstractos que deben implementar las subclases
    public abstract string MixIngredients();
    public abstract string Bake();

    /// <summary>
    /// Paso concreto común a todos los tipos de pan
    /// </summary>
    public string Slice()
    {
        return $"Cortando el pan {GetType().Name}";
    }

    /// <summary>
    /// TEMPLATE METHOD - Define el algoritmo general para hacer pan
    /// </summary>
    public string Make()
    {
        var result = string.Empty;
        result = MixIngredients();    // Paso 1: Mezclar ingredientes
        result += " ; " + Bake();     // Paso 2: Hornear
        result += " ; " + Slice();    // Paso 3: Cortar
        return result;
    }
}

/// <summary>
/// Implementación concreta - Pan blanco
/// </summary>
public class Blanco : Bread
{
    public override string Bake()
    {
        return "Colocando ingredientes para el pan blanco";
    }

    public override string MixIngredients()
    {
        return "horneando pan blanco (24 min)";
    }
}

/// <summary>
/// Implementación concreta - Pan integral
/// </summary>
public class Integral : Bread
{
    public override string Bake()
    {
        return "Horneando pan integral (10 min)";
    }

    public override string MixIngredients()
    {
        return "Colocando ingredientes pan integral";
    }
}