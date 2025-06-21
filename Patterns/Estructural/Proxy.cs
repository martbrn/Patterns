namespace Patterns.Estructural;

// ======================================================================
// PATRÓN PROXY
// ======================================================================
/// Proporciona un sustituto o marcador de posición para otro objeto para controlar el acceso a él.
/// Permite realizar validaciones, control de acceso, lazy loading, etc. antes de delegar al objeto real.

/// <summary>
/// Interfaz común que define las operaciones disponibles.
/// Tanto el objeto real como el proxy implementan esta interfaz.
/// </summary>
public interface ICar
{
    bool Drive();
}

/// <summary>
/// Objeto real (RealSubject) que contiene la lógica de negocio principal.
/// Representa el recurso costoso o sensible al que queremos controlar el acceso.
/// </summary>
public class Car : ICar
{
    /// <summary>
    /// Implementación real de la funcionalidad de conducir.
    /// </summary>
    /// <returns>true si se puede conducir</returns>
    public bool Drive() => true;
}

/// <summary>
/// Clase auxiliar que representa al conductor y sus credenciales.
/// Contiene la información necesaria para validar si puede usar el recurso.
/// </summary>
public class Driver
{
    private int _age;
    private bool _hasLicense;

    public Driver(int age, bool hasLicense)
    {
        _age = age;
        _hasLicense = hasLicense;
    }

    /// <summary>
    /// Lógica de validación: determina si el conductor puede conducir.
    /// Encapsula las reglas de negocio para el control de acceso.
    /// </summary>
    /// <returns>true si cumple los requisitos para conducir</returns>
    internal bool CanDrive() => _age >= 18 && _hasLicense;
}

/// <summary>
/// Clase Proxy que controla el acceso al objeto Car real.
/// Implementa la misma interfaz que el objeto real pero añade lógica de control de acceso.
/// Tipo de proxy: Protection Proxy (controla permisos de acceso).
/// </summary>
public class CarProxy : ICar
{
    /// <summary>
    /// Referencia al objeto real que el proxy representa.
    /// El proxy delega las operaciones a este objeto cuando es apropiado.
    /// </summary>
    private Car _car = new Car();

    /// <summary>
    /// Información adicional necesaria para el control de acceso.
    /// </summary>
    private Driver _driver;

    public CarProxy(Driver driver)
    {
        _driver = driver;
    }

    /// <summary>
    /// Método proxy que controla el acceso al método Drive() del objeto real.
    /// Realiza validaciones antes de delegar la llamada al objeto real.
    /// </summary>
    /// <returns>true si el conductor puede y logra conducir, false en caso contrario</returns>
    public bool Drive()
    {
        // Control de acceso: validamos permisos antes de permitir la operación
        if (_driver.CanDrive())
            return _car.Drive(); // Delegamos al objeto real
        else
            return false; // Bloqueamos el acceso
    }
}