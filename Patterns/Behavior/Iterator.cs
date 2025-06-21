namespace Patterns.Behavior;

// ======================================================================
// PATRÓN ITERATOR (Iterador)
// ======================================================================
// Proporciona un modo de acceder secuencialmente a los elementos de un
// objeto agregado sin exponer su representación interna.

/// <summary>
/// Clase que representa un elemento del menú
/// </summary>
public class Menu
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public double Price { get; private set; }
    public bool IsVegatarian { get; private set; }

    public Menu(string name, string description, double price, bool isVegatarian)
    {
        Name = name;
        Description = description;
        Price = price;
        IsVegatarian = isVegatarian;
    }
}

/// <summary>
/// Interfaz del Iterator - Define la navegación por la colección
/// </summary>
public interface IIterator<T>
{
    bool HasNext();  // Verifica si hay más elementos
    T Next();        // Obtiene el siguiente elemento
}

/// <summary>
/// Iterator concreto para el menú de desayunos
/// </summary>
public class BreakfastMenuIterator : IIterator<Menu>
{
    List<Menu> items;
    int position = 0;  // Posición actual en la iteración

    public BreakfastMenuIterator(List<Menu> items)
    {
        this.items = items;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Verifica si hay más elementos para iterar
    /// </summary>
    public bool HasNext()
    {
        if (position >= items.Count || items[position] == null)
            return false;
        else
            return true;
    }

    /// <summary>
    /// Obtiene el siguiente elemento y avanza la posición
    /// </summary>
    public Menu Next()
    {
        Menu menu = items[position];
        position = position + 1;
        return menu;
    }
}

/// <summary>
/// Agregado concreto - Colección de menús de desayuno
/// </summary>
public class BreakfastMenuCollection
{
    private List<Menu> _menuItems;

    public BreakfastMenuCollection()
    {
        _menuItems = new List<Menu>();
        // Inicialización con datos de ejemplo
        AddItem("Desyuno simple dulce", "Panqueques con manjar + cafe o te", 200, false);
        AddItem("Desyuno Sandwich", "Sandwich Jamon queso + cafe o te", 120, false);
        AddItem("Desyuno vegetariano", "Sandwich Lechuga y atun + jugo", 200, true);
    }

    /// <summary>
    /// Añade un elemento al menú
    /// </summary>
    public void AddItem(string name, string description, double price, bool isVegatarian)
    {
        Menu menuItem = new Menu(name, description, price, isVegatarian);
        _menuItems.Add(menuItem);
    }

    /// <summary>
    /// Factory method para crear el iterator
    /// </summary>
    public IIterator<Menu> CreateIterator() => new BreakfastMenuIterator(_menuItems);
}