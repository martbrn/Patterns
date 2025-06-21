namespace Patterns.Estructural;

// ======================================================================
// PATRÓN FLYWEIGHT (PESO MOSCA)
// ======================================================================
/// Minimiza el uso de memoria compartiendo eficientemente grandes cantidades de objetos similares.
/// Separa el estado intrínseco (compartido) del extrínseco (contextual).

/// <summary>
/// Clase Flyweight que representa un carácter.
/// Contiene solo el estado intrínseco (el símbolo del carácter) que es compartido entre múltiples contextos.
/// El estado extrínseco (posición, color, etc.) se maneja externamente.
/// </summary>
public class Character
{
    /// <summary>
    /// Estado intrínseco: el símbolo del carácter que es compartido.
    /// Este dato no cambia y puede ser reutilizado por múltiples contextos.
    /// </summary>
    public char Symbol { get; private set; }

    /// <summary>
    /// Constructor que inicializa el estado intrínseco.
    /// </summary>
    /// <param name="symbol">El carácter que representa este flyweight</param>
    public Character(char symbol)
    {
        Symbol = symbol;
    }
}

/// <summary>
/// Factory que gestiona los objetos Flyweight.
/// Garantiza que los flyweights se compartan apropiadamente y no se dupliquen innecesariamente.
/// Utiliza un pool de objetos para reutilizar instancias existentes.
/// </summary>
public class CharacterFactory
{
    /// <summary>
    /// Pool de flyweights: almacena las instancias de Character ya creadas.
    /// La clave es el símbolo y el valor es la instancia reutilizable.
    /// </summary>
    private readonly Dictionary<char, Character> _characters = new();

    /// <summary>
    /// Método factory que devuelve un flyweight existente o crea uno nuevo si no existe.
    /// Implementa el patrón Singleton por carácter para garantizar la reutilización.
    /// </summary>
    /// <param name="symbol">El símbolo del carácter solicitado</param>
    /// <returns>Una instancia de Character (nueva o reutilizada)</returns>
    public Character GetCharacter(char symbol)
    {
        // Si no existe el carácter en el pool, lo creamos
        if (!_characters.ContainsKey(symbol))
            _characters[symbol] = new Character(symbol);

        // Devolvemos la instancia existente (reutilización)
        return _characters[symbol];
    }

    /// <summary>
    /// Propiedad que indica cuántos flyweights únicos se han creado.
    /// Útil para monitorear la eficiencia del patrón.
    /// </summary>
    public int Count => _characters.Count;
}