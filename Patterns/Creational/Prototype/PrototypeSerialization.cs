// =============================================
// PROTOTYPE PATTERN - Serialization Implementation
// =============================================
// Propósito: Implementar clonación profunda usando serialización JSON
// Ventaja: Automático para objetos complejos, no requiere implementación manual

using System.Text.Json;

namespace Patterns.Creational.Prototype;

/// <summary>
/// Métodos de extensión para implementar clonación profunda mediante serialización
/// Utiliza JSON para crear copias independientes de cualquier objeto serializable
/// </summary>
public static class ExtensionMethods
{
    /// <summary>
    /// Crea una copia profunda de cualquier objeto serializable usando JSON
    /// </summary>
    /// <typeparam name="T">Tipo del objeto a clonar</typeparam>
    /// <param name="self">Objeto a clonar</param>
    /// <returns>Copia profunda del objeto</returns>
    public static T DeepCopy<T>(this T self)
    {
        // Serializar el objeto a JSON en memoria
        var stream = new MemoryStream();
        JsonSerializer.Serialize(stream, self);
        stream.Seek(0, SeekOrigin.Begin);

        // Deserializar desde JSON para crear nueva instancia
        var copy = JsonSerializer.Deserialize<T>(stream);
        stream.Close();
        return copy!;
    }
}

/// <summary>
/// Clase Category serializable para usar con el método de extensión DeepCopy
/// </summary>
[Serializable]
public class Category
{
    public string Name { get; set; }

    public Category(string name)
    {
        Name = name;
    }
}

/// <summary>
/// Clase Product serializable que puede ser clonada automáticamente
/// </summary>
[Serializable]
public class Product
{
    public string Name { get; set; }
    public Category Category { get; set; }

    public Product(string name, Category category)
    {
        Name = name;
        Category = category;
    }

    public override string ToString() => $"Producto: {Name}, Categoría: {Category.Name}";
}