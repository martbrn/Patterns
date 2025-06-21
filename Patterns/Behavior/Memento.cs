namespace Patterns.Behavior;

// ======================================================================
// PATRÓN MEMENTO (Recuerdo)
// ======================================================================
// Captura y externaliza el estado interno de un objeto sin violar
// la encapsulación, permitiendo restaurar el objeto a ese estado más tarde.

/// <summary>
/// Clase Memento - Almacena el estado interno del Originator
/// </summary>
public class Memento
{
    public int Balance { get; }  // Estado inmutable

    public Memento(int balance)
    {
        Balance = balance;
    }
}

/// <summary>
/// Originator - Objeto cuyo estado queremos preservar
/// </summary>
public class Account
{
    public int Balance { get; set; }
    private int _current;  // Índice del memento actual
    private List<Memento> _operations = new();  // Historial de estados

    public Account(int balance)
    {
        Balance = balance;
        _operations.Add(new Memento(balance));  // Estado inicial
    }

    /// <summary>
    /// Operación que modifica el estado y crea un memento
    /// </summary>
    public Memento Deposit(int amount)
    {
        Balance += amount;
        var memento = new Memento(Balance);
        _operations.Add(memento);
        ++_current;
        return memento;
    }

    /// <summary>
    /// Deshace la última operación
    /// </summary>
    public Memento? Undo()
    {
        if (_current > 0)
        {
            var memento = _operations[--_current];
            Balance = memento.Balance;
            return memento;
        }
        return null;
    }

    /// <summary>
    /// Rehace una operación previamente deshecha
    /// </summary>
    public Memento? Redo()
    {
        if (_current + 1 < _operations.Count)
        {
            var memento = _operations[++_current];
            Balance = memento.Balance;
            return memento;
        }
        return null;
    }

    /// <summary>
    /// Restaura el estado desde un memento específico
    /// </summary>
    public void Restore(Memento memento)
    {
        Balance = memento.Balance;
    }
}