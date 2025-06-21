// =============================================
// PROTOTYPE PATTERN - ICloneable Implementation
// =============================================
// Propósito: Usar la interfaz ICloneable de .NET para implementar clonación
// Nota: ICloneable es ambigua (shallow vs deep copy), mejor usar implementaciones específicas

namespace Patterns.Creational.Prototype.Clonable;

/// <summary>
/// Implementación de Category usando ICloneable
/// Demuestra el uso de la interfaz estándar de .NET para clonación
/// </summary>
public class Category : ICloneable
{
    public string Name { get; set; }

    public Category(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Implementa ICloneable.Clone() para crear copia de la categoría
    /// </summary>
    public object Clone() => new Category(Name);
}

/// <summary>
/// Implementación de Product usando ICloneable con clonación profunda
/// </summary>
public class Product : ICloneable
{
    public string Name { get; set; }
    public Category Category { get; set; }

    public Product(string name, Category category)
    {
        Name = name;
        Category = category;
    }

    public override string ToString() => $"Producto: {Name}, Categoría: {Category.Name}";

    /// <summary>
    /// Implementa clonación profunda clonando también la categoría asociada
    /// </summary>
    public object Clone() => new Product(Name, (Category)Category.Clone());
}
