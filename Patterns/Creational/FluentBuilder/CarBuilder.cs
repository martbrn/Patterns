// =============================================
// BUILDER PATTERN - Fluent Interface
// =============================================
// Propósito: Construir objetos complejos paso a paso con una interfaz fluida
// Cuándo usar: Cuando tienes objetos con muchos parámetros opcionales o construcción compleja

namespace Patterns.Creational.FluentBuilder;

/// <summary>
/// Implementación del patrón Builder con interfaz fluida
/// Permite construir objetos Car de manera legible y flexible
/// </summary>
public class CarBuilder
{
    /// <summary>
    /// Clase interna que representa el producto final a construir
    /// Sealed para prevenir herencia no deseada
    /// </summary>
    public sealed class Car
    {
        public string Name { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        public override string ToString() => $"Mi automovil es {Name}, Modelo: {Model}";
    }

    // Instancia del objeto que se está construyendo
    private readonly Car _car = new();

    // Constructor privado para forzar uso del método factory
    private CarBuilder() { }

    /// <summary>
    /// Método factory para crear una nueva instancia del builder
    /// </summary>
    public static CarBuilder CreateNew() => new CarBuilder();

    /// <summary>
    /// Método fluido para establecer el nombre del automóvil
    /// </summary>
    /// <param name="name">Nombre del automóvil</param>
    /// <returns>La misma instancia del builder para encadenamiento</returns>
    public CarBuilder AddName(string name)
    {
        _car.Name = name;
        return this; // Retorna this para permitir method chaining
    }

    /// <summary>
    /// Método fluido para establecer el modelo del automóvil
    /// </summary>
    /// <param name="model">Modelo del automóvil</param>
    /// <returns>La misma instancia del builder para encadenamiento</returns>
    public CarBuilder AddModel(string model)
    {
        _car.Model = model;
        return this; // Retorna this para permitir method chaining
    }

    /// <summary>
    /// Método final que retorna el objeto construido
    /// </summary>
    /// <returns>Instancia completa del automóvil</returns>
    public Car Build()
    {
        return _car;
    }
}