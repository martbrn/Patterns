namespace Patterns.Behavior;

// ======================================================================
// PATRÓN STRATEGY (Estrategia)
// ======================================================================
// Define una familia de algoritmos, los encapsula y los hace intercambiables.

using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Enumeración de formatos de salida disponibles
/// </summary>
public enum OutputFormat
{
    NumberList,  // Lista numerada
    Html         // Lista HTML
}

/// <summary>
/// Interfaz de la Estrategia - Define el algoritmo de formateo
/// </summary>
public interface IListFormatStrategy
{
    void Start(StringBuilder sb);           // Inicio del formato
    void AddItem(StringBuilder sb, string item);  // Añadir elemento
    void End(StringBuilder sb);             // Fin del formato
}

/// <summary>
/// Estrategia concreta - Formato HTML
/// </summary>
public class Html : IListFormatStrategy
{
    public void Start(StringBuilder sb) => sb.AppendLine("<ul>");
    public void AddItem(StringBuilder sb, string item) => sb.AppendLine($" <li>{item}</li>");
    public void End(StringBuilder sb) => sb.AppendLine("</ul>");
}

/// <summary>
/// Estrategia concreta - Lista numerada
/// </summary>
public class NumberList : IListFormatStrategy
{
    public void AddItem(StringBuilder sb, string item)
    {
        var itemNumber = Regex.Matches(sb.ToString(), Environment.NewLine).Count + 1;
        sb.AppendLine($"{itemNumber} {item}");
    }

    public void End(StringBuilder sb) { }
    public void Start(StringBuilder sb) { }
}

/// <summary>
/// Contexto del patrón Strategy - Utiliza la estrategia seleccionada
/// </summary>
public class TextProcessor
{
    public StringBuilder sb { get; set; } = new StringBuilder();
    private IListFormatStrategy _listStrategy { get; set; }

    /// <summary>
    /// Constructor que selecciona la estrategia basada en el formato
    /// </summary>
    public TextProcessor(OutputFormat format)
    {
        // Uso de reflexión para instanciar la estrategia
        var className = $"Patterns.Behavior.{Enum.GetName(typeof(OutputFormat), format)}";
        var strategyType = Type.GetType(className);

        if (strategyType == null)
            throw new InvalidOperationException($"No se pudo encontrar la estrategia '{className}'");

        _listStrategy = (IListFormatStrategy)Activator.CreateInstance(strategyType)!;
    }

    /// <summary>
    /// Aplica la estrategia seleccionada para formatear la lista
    /// </summary>
    public void AppendList(IEnumerable<string> items)
    {
        _listStrategy.Start(sb);
        foreach (var item in items)
            _listStrategy.AddItem(sb, item);
        _listStrategy.End(sb);
    }

    public StringBuilder Clear() => sb.Clear();
    public override string ToString() => sb.ToString();
}