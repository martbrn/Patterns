namespace Patterns.Behavior;

// ======================================================================
// PATRÓN ChainOfResponsibility (Cadena de Responsabilidad)
// ======================================================================
// Este patrón permite pasar una solicitud a lo largo de una cadena de manejadores,
// donde cada manejador decide si procesa la solicitud o la pasa al siguiente.
// Ideal para escenarios donde múltiples objetos pueden manejar una solicitud.
public abstract class Handler
{
    protected Handler _next;

    /// <summary>
    /// Establece el siguiente manejador en la cadena.
    /// </summary>
    public void SetNext(Handler next) => _next = next;

    /// <summary>
    /// Método que define cómo manejar la solicitud.
    /// Debe ser implementado por las subclases.
    /// </summary>
    public abstract string Handle(string request);
}

/// <summary>
/// Manejador para solicitudes de nivel bajo.
/// Procesa solicitudes con valor "low", o las pasa al siguiente manejador.
/// </summary>
public class LowLevelHandler : Handler
{
    public override string Handle(string request)
    {
        if (request == "low")
            return "Handled by LowLevel";

        /// Pasa la solicitud al siguiente manejador si existe
        return _next?.Handle(request);
    }
}

/// <summary>
/// Manejador para solicitudes de nivel alto.
/// Procesa solicitudes con valor "high", o las pasa al siguiente manejador.
/// </summary>
public class HighLevelHandler : Handler
{
    public override string Handle(string request)
    {
        if (request == "high")
            return "Handled by HighLevel";

        /// Pasa la solicitud al siguiente manejador o retorna "Not handled" si no hay más
        return _next?.Handle(request) ?? "Not handled";
    }
}