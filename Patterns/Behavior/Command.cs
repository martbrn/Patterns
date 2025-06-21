namespace Patterns.Behavior;

// ======================================================================
// PATRÓN COMMAND (Comando)
// ======================================================================
// Encapsula una solicitud como un objeto, permitiendo parametrizar clientes
// con diferentes solicitudes, encolar operaciones y soportar deshacer.

/// <summary>
/// Enumeración que define los tipos de acciones que se pueden realizar sobre el precio
/// </summary>
public enum PriceAction
{
    Increase = 0,  // Incrementar precio
    Decrease = 1   // Decrementar precio
}

/// <summary>
/// Clase que representa un producto con operaciones de modificación de precio
/// </summary>
public class Product
{
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    /// <summary>
    /// Incrementa el precio del producto
    /// </summary>
    /// <param name="amount">Cantidad a incrementar</param>
    public void IncreasePrice(int amount)
    {
        Price += amount;
    }

    /// <summary>
    /// Disminuye el precio del producto si es posible
    /// </summary>
    /// <param name="amount">Cantidad a decrementar</param>
    /// <returns>True si se pudo decrementar, False si no</returns>
    public bool DecreasePrice(int amount)
    {
        if (amount < Price)
        {
            Price -= amount;
            return true;
        }
        return false;
    }

    public override string ToString() => $"El precio actual de {Name} es {Price}";
}

/// <summary>
/// Interfaz del patrón Command - Define la operación Execute y Undo
/// </summary>
public interface ICommand
{
    void Execute();  // Ejecutar el comando
    void Undo();     // Deshacer el comando
}

/// <summary>
/// Implementación concreta del Command para operaciones de precio en productos
/// </summary>
public class ProductCommand : ICommand
{
    private Product _product;           // Receptor del comando
    private PriceAction _priceAction;   // Acción a realizar
    private int _amount;                // Cantidad
    public bool IsCommandExecuted { get; private set; }

    public ProductCommand(Product product, PriceAction priceAction, int amount)
    {
        _product = product;
        _priceAction = priceAction;
        _amount = amount;
    }

    /// <summary>
    /// Ejecuta el comando según la acción especificada
    /// </summary>
    public void Execute()
    {
        if (_priceAction == PriceAction.Increase)
        {
            _product.IncreasePrice(_amount);
            IsCommandExecuted = true;
        }
        else
            IsCommandExecuted = _product.DecreasePrice(_amount);
    }

    /// <summary>
    /// Deshace el comando ejecutado previamente
    /// </summary>
    public void Undo()
    {
        if (!IsCommandExecuted)
            return;

        // Operación inversa: si se incrementó, se decrementa y viceversa
        if (_priceAction == PriceAction.Increase)
            _product.DecreasePrice(_amount);
        else
            _product.IncreasePrice(_amount);
    }
}

/// <summary>
/// Invoker del patrón Command - Gestiona la ejecución y historial de comandos
/// </summary>
public class ModifyPrice
{
    private List<ICommand> _commands = new();   // Historial de comandos
    private ICommand _command { get; set; }     // Comando actual

    /// <summary>
    /// Establece el comando a ejecutar
    /// </summary>
    public void SetCommand(ICommand command) => _command = command;

    /// <summary>
    /// Ejecuta el comando y lo añade al historial
    /// </summary>
    public void Invoke()
    {
        _commands.Add(_command);
        _command.Execute();
    }

    /// <summary>
    /// Deshace todos los comandos en orden inverso
    /// </summary>
    public void Undo()
    {
        foreach (var command in Enumerable.Reverse(_commands))
        {
            command.Undo();
        }
    }
}