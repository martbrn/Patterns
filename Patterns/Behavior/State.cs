namespace Patterns.Behavior;

// ======================================================================
// PATRÓN STATE (Estado)
// ======================================================================
// Permite que un objeto altere su comportamiento cuando su estado interno cambia.

/// <summary>
/// Interfaz del Estado - Define el comportamiento asociado a un estado
/// </summary>
public interface IState
{
    string Handle();
}

/// <summary>
/// Estado concreto - Sistema encendido
/// </summary>
public class OnState : IState
{
    public string Handle() => "System On";
}

/// <summary>
/// Estado concreto - Sistema apagado
/// </summary>
public class OffState : IState
{
    public string Handle() => "System Off";
}

/// <summary>
/// Contexto del patrón State - Mantiene referencia al estado actual
/// </summary>
public class Context
{
    private IState _state;

    public Context(IState state) => _state = state;

    /// <summary>
    /// Cambia el estado actual
    /// </summary>
    public void SetState(IState state) => _state = state;

    /// <summary>
    /// Delega la petición al estado actual
    /// </summary>
    public string Request() => _state.Handle();
}