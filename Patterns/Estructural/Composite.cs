namespace Patterns.Estructural;

// ======================================================================
/// PATRÓN COMPOSITE (COMPUESTO)
// ======================================================================
/// Compone objetos en estructuras de árbol para representar jerarquías parte-todo.
/// Permite a los clientes tratar objetos individuales y composiciones de objetos de manera uniforme.
/// Útil para representar estructuras jerárquicas como sistemas de archivos, organizaciones, etc.
/// </summary>

/// <summary>
/// Clase base abstracta (Component) que define la interfaz común para objetos simples y compuestos.
/// Define las operaciones que pueden realizarse tanto en hojas como en composites.
/// Permite tratar uniformemente a objetos individuales y colecciones de objetos.
/// </summary>
public abstract class Product
{
    public string Name { get; private set; }
    public int Price { get; private set; }

    protected Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    /// <summary>
    /// Operación para añadir un producto hijo.
    /// Tiene sentido para composites, pero no para hojas.
    /// </summary>
    public abstract void Add(Product product);

    /// <summary>
    /// Operación para eliminar un producto hijo.
    /// Tiene sentido para composites, pero no para hojas.
    /// </summary>
    public abstract void Remove(Product product);

    /// <summary>
    /// Operación común que debe implementar tanto hojas como composites.
    /// Esta operación se puede aplicar recursivamente en toda la estructura.
    /// </summary>
    public abstract string GetPrice();
}

/// <summary>
/// Clase hoja (Leaf) que representa un producto individual sin hijos.
/// No puede contener otros productos y representa los elementos terminales del árbol.
/// Implementa las operaciones del Component de manera que tenga sentido para un objeto individual.
/// </summary>
public class SimpleProduct : Product
{
    public SimpleProduct(string name, int price) : base(name, price)
    {
    }

    /// <summary>
    /// Las operaciones de manejo de hijos no aplican a las hojas.
    /// Se implementan como operaciones vacías o que lanzan excepciones.
    /// </summary>
    public override void Add(Product product)
    {
        // Operación no se puede realizar porque es el elemento que se encuentra más abajo en la jerarquía
        // En una implementación real, podría lanzar una NotSupportedException
    }

    /// <summary>
    /// Las operaciones de manejo de hijos no aplican a las hojas.
    /// </summary>
    public override void Remove(Product product)
    {
        // Operación no se puede realizar porque es el elemento que se encuentra más abajo en la jerarquía
        // En una implementación real, podría lanzar una NotSupportedException
    }

    /// <summary>
    /// Implementación de la operación común para una hoja.
    /// Devuelve información específica del producto individual.
    /// </summary>
    public override string GetPrice()
    {
        return $"El precio de {Name} es {Price.ToString("N2")}";
    }
}

/// <summary>
/// Clase compuesta (Composite) que puede contener otros productos (hojas u otros composites).
/// Representa las ramas del árbol que tienen hijos.
/// Implementa operaciones de manejo de hijos y delega operaciones a sus componentes hijos.
/// </summary>
public class CompositeProduct : Product
{
    /// <summary>
    /// Colección de productos hijos (pueden ser SimpleProduct u otros CompositeProduct).
    /// Esta es la estructura que permite construir el árbol jerárquico.
    /// </summary>
    List<Product> _products = new();

    /// <summary>
    /// Constructor que inicializa un composite con precio 0 (se calculará basado en los hijos).
    /// </summary>
    public CompositeProduct(string name) : base(name, 0)
    {
    }

    /// <summary>
    /// Añade un producto hijo al composite.
    /// Permite construir la estructura jerárquica dinámicamente.
    /// </summary>
    public override void Add(Product product)
    {
        _products.Add(product);
    }

    /// <summary>
    /// Calcula el precio total del composite basado en sus hijos.
    /// Esta operación se aplica recursivamente: si un hijo es composite, 
    /// también calculará su precio basado en sus propios hijos.
    /// Demuestra cómo se pueden tratar uniformemente hojas y composites.
    /// </summary>
    public override string GetPrice()
    {
        // La operación se propaga a todos los hijos automáticamente
        // gracias a que todos implementan la misma interfaz (Product)
        return $"El precio de {Name} es {_products.Sum(o => o.Price).ToString("N2")}";
    }

    /// <summary>
    /// Elimina un producto hijo del composite.
    /// </summary>
    public override void Remove(Product product)
    {
        _products.Remove(product);
    }
}