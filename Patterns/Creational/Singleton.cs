// =============================================
// SINGLETON PATTERN
// =============================================
// Propósito: Garantizar que una clase tenga una sola instancia y proporcionar un punto de acceso global a ella.
// Cuándo usar: Cuando necesites exactamente una instancia de una clase (ej: logger, configuración, pool de conexiones)

namespace Patterns.Creational;

/// <summary>
/// Implementación del patrón Singleton con thread-safety usando lock
/// Garantiza que solo exista una instancia de la clase en toda la aplicación
/// </summary>
public class Singleton
{
    // Campo estático privado que almacena la única instancia
    private static Singleton _instance;

    // Objeto para sincronización de hilos (thread-safety)
    private static readonly object _lock = new();

    // Constructor privado para prevenir instanciación externa
    private Singleton() { }

    /// <summary>
    /// Propiedad pública que proporciona acceso a la instancia única
    /// Implementa lazy initialization con thread-safety
    /// </summary>
    public static Singleton Instance
    {
        get
        {
            // Sincronización para evitar problemas de concurrencia
            lock (_lock)
            {
                // Operador de coalescencia nula: si _instance es null, crea nueva instancia
                return _instance ??= new Singleton();
            }
        }
    }

    /// <summary>
    /// Método de ejemplo para demostrar funcionalidad del singleton
    /// </summary>
    public string SayHello() => "Hello from Singleton";
}
