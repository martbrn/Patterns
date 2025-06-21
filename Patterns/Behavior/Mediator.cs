namespace Patterns.Behavior;

// ======================================================================
// PATRÓN MEDIATOR (Mediador)
// ======================================================================
// Define cómo un conjunto de objetos interactúan entre sí, promoviendo
// el bajo acoplamiento al evitar que los objetos se refieran explícitamente.

/// <summary>
/// Interfaz del Mediator - Define las operaciones de mediación
/// </summary>
public interface IMediator
{
    void RegisterRunway(Runway runway);
    void RegisterFlight(Flight flight);
    bool IsLandingOk();
    void SetLandingStatus(bool status);
}

/// <summary>
/// Mediator concreto - Controla la comunicación entre vuelos y pistas
/// </summary>
public class Mediator : IMediator
{
    private Flight _flight;
    private Runway _runway;
    private bool _land;  // Estado de disponibilidad para aterrizar

    public bool IsLandingOk() => _land;

    public void RegisterFlight(Flight flight)
    {
        _flight = flight;
    }

    public void RegisterRunway(Runway runway)
    {
        _runway = runway;
    }

    public void SetLandingStatus(bool status)
    {
        _land = status;
    }
}

/// <summary>
/// Colega concreto - Vuelo que necesita aterrizar
/// </summary>
public class Flight
{
    private IMediator _mediator;

    public Flight(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Solicita permiso para aterrizar a través del mediador
    /// </summary>
    public string Land()
    {
        if (_mediator.IsLandingOk())
        {
            _mediator.SetLandingStatus(true);
            return "Se puede aterrizar";
        }
        else
            return "Esperando disponibilidad";
    }
}

/// <summary>
/// Colega concreto - Pista de aterrizaje
/// </summary>
public class Runway
{
    private IMediator _mediator;

    public Runway(IMediator mediator)
    {
        _mediator = mediator;
        _mediator.SetLandingStatus(false);  // Inicialmente no disponible
    }

    /// <summary>
    /// Otorga permiso para aterrizar a través del mediador
    /// </summary>
    public string Land()
    {
        _mediator.SetLandingStatus(true);
        return "Permiso para aterrizar";
    }
}
