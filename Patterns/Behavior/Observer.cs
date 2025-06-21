namespace Patterns.Behavior;

// ======================================================================
// PATRÓN OBSERVER (Observador)
// ======================================================================
// Define una dependencia uno-a-muchos entre objetos, de modo que cuando
// un objeto cambia de estado, todos sus dependientes son notificados.

/// <summary>
/// Interfaz del Observer - Define el método de actualización
/// </summary>
public interface IRestaurant
{
    string Update(Fruits fruits);
}

/// <summary>
/// Clase Subject abstracta - Mantiene lista de observadores y los notifica
/// </summary>
public abstract class Fruits
{
    private List<IRestaurant> _restaurants = new();  // Lista de observadores
    private double _pricePerKg;

    protected Fruits(double pricePerKg)
    {
        _pricePerKg = pricePerKg;
    }

    /// <summary>
    /// Añade un observador a la lista
    /// </summary>
    public void Attach(IRestaurant restaurant) => _restaurants.Add(restaurant);

    /// <summary>
    /// Remueve un observador de la lista
    /// </summary>
    public void Detach(IRestaurant restaurant) => _restaurants.Remove(restaurant);

    /// <summary>
    /// Notifica a todos los observadores del cambio de estado
    /// </summary>
    public void Notify()
    {
        foreach (IRestaurant restaurant in _restaurants)
            restaurant.Update(this);
    }

    /// <summary>
    /// Propiedad que notifica automáticamente cuando cambia el precio
    /// </summary>
    public double PricePerKg
    {
        get { return _pricePerKg; }
        set
        {
            if (_pricePerKg != value)
            {
                _pricePerKg = value;
                Notify();  // Notifica automáticamente el cambio
            }
        }
    }
}

/// <summary>
/// Subject concreto - Representa un tipo específico de fruta
/// </summary>
public class Limon : Fruits
{
    public Limon(double pricePerKg) : base(pricePerKg)
    {
    }
}

/// <summary>
/// Observer concreto - Restaurante que reacciona a cambios de precio
/// </summary>
public class Restaurant : IRestaurant
{
    private string _name;
    public double _purchaseThreshold { get; set; }  // Umbral de compra

    public Restaurant(string name, double purchaseThreshold)
    {
        _name = name;
        _purchaseThreshold = purchaseThreshold;
    }

    /// <summary>
    /// Reacciona al cambio de precio de la fruta
    /// </summary>
    public string Update(Fruits fruits)
    {
        if (fruits.PricePerKg < _purchaseThreshold)
            return $"{_name} quiere comprar algunos {fruits.GetType().Name}es!";

        return string.Empty;
    }
}