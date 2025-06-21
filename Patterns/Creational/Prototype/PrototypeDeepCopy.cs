// =============================================
// PROTOTYPE PATTERN - Deep Copy Implementation
// =============================================
// Propósito: Crear nuevos objetos clonando instancias existentes en lugar de crear desde cero
// Cuándo usar: Cuando la creación de objetos es costosa o compleja, y necesitas copias independientes

namespace Patterns.Creational.Prototype.DeepCopy;

/// <summary>
/// Interfaz genérica para implementar el patrón Prototype
/// Define el contrato para crear copias profundas de objetos
/// </summary>
/// <typeparam name="T">Tipo del objeto a clonar</typeparam>
interface IPrototype<T>
{
    /// <summary>
    /// Crea una copia profunda del objeto actual
    /// </summary>
    /// <returns>Nueva instancia con los mismos valores pero independiente</returns>
    T DeepCopy();
}

/// <summary>
/// Clase Category que implementa el patrón Prototype
/// Representa una categoría que puede ser clonada
/// </summary>
public class Category : IPrototype<Category>
{
    public string Name { get; set; }

    public Category(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Implementación de copia profunda para Category
    /// Crea una nueva instancia con el mismo nombre
    /// </summary>
    public Category DeepCopy() => new Category(Name);
}

/// <summary>
/// Clase Product que implementa el patrón Prototype con objeto anidado
/// Demuestra cómo hacer copia profunda de objetos complejos
/// </summary>
public class Product : IPrototype<Product>
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
    /// Implementación de copia profunda para Product
    /// Clona tanto el producto como su categoría asociada
    /// </summary>
    public Product DeepCopy() => new Product(Name, Category.DeepCopy());
}