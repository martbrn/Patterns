namespace Patterns.Estructural;

// ======================================================================
// PATRÓN FACADE (FACHADA)
// ======================================================================
/// Proporciona una interfaz simplificada para un conjunto de interfaces en un subsistema.
/// Define una interfaz de nivel superior que hace que el subsistema sea más fácil de usar.
/// </summary>

/// <summary>
/// Clase Facade que simplifica la interacción con múltiples controladores del hogar inteligente.
/// Encapsula la complejidad de manejar varios dispositivos en métodos simples.
/// </summary>
public class HomeController
{
    // Subsistemas complejos que el Facade encapsula
    private WifiController _wifiController = new WifiController();
    private AirConditionerController _airController = new AirConditionerController();
    private LightController _lightController = new LightController();

    /// <summary>
    /// Método facade que enciende todos los dispositivos del hogar de una vez.
    /// El cliente no necesita conocer los detalles de cada controlador individual.
    /// </summary>
    /// <returns>Lista de mensajes confirmando el encendido de cada dispositivo</returns>
    public List<string> TurnOn()
    {
        return new List<string>()
        {
            _wifiController.TurnOn(),
            _airController.TurnOn(),
            _lightController.TurnOn()
        };
    }

    /// <summary>
    /// Método facade que apaga todos los dispositivos del hogar de una vez.
    /// Simplifica una operación compleja en una sola llamada.
    /// </summary>
    /// <returns>Lista de mensajes confirmando el apagado de cada dispositivo</returns>
    public List<string> TurnOff()
    {
        return new List<string>()
        {
            _wifiController.TurnOff(),
            _airController.TurnOff(),
            _lightController.TurnOff()
        };
    }
}

/// <summary>
/// Subsistema 1: Controlador del WiFi
/// Representa una parte del sistema complejo que el Facade encapsula.
/// </summary>
public class WifiController
{
    public string TurnOn()
    {
        return "Wifi is on";
    }

    public string TurnOff()
    {
        return "Wifi is off";
    }
}

/// <summary>
/// Subsistema 2: Controlador del aire acondicionado
/// Otra parte del sistema complejo manejada por el Facade.
/// </summary>
public class AirConditionerController
{
    public string TurnOn()
    {
        return "Aire acondicionado is on";
    }
    public string TurnOff()
    {
        return "Aire acondicionado is off";
    }
}

/// <summary>
/// Subsistema 3: Controlador de luces
/// Tercera parte del sistema que el Facade simplifica para el cliente.
/// </summary>
public class LightController
{
    public string TurnOn()
    {
        return "Luz is on";
    }
    public string TurnOff()
    {
        return "Luz is off";
    }
}