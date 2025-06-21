namespace Patterns.Estructural;

// ======================================================================
// PATRÓN BRIDGE (PUENTE)
// ======================================================================
/// Separa una abstracción de su implementación para que ambas puedan variar independientemente.
/// Desacopla la jerarquía de abstracción de la jerarquía de implementación.
/// Evita la explosión combinatoria de clases cuando se tienen múltiples dimensiones de variación.
/// </summary>

/// <summary>
/// Interfaz de implementación (Implementor) que define los métodos básicos.
/// Esta jerarquía puede evolucionar independientemente de la abstracción.
/// Define cómo se muestran los datos, pero no qué aplicación los muestra.
/// </summary>
public interface IDisplayFormatter
{
    string Display(string text);
}

/// <summary>
/// Clase de abstracción (Abstraction) que define la interfaz de alto nivel.
/// Mantiene una referencia a un objeto de tipo Implementor.
/// Esta jerarquía puede evolucionar independientemente de la implementación.
/// Define qué aplicación muestra los datos, pero delega el cómo al formatter.
/// </summary>
public abstract class ReaderApp
{
    /// <summary>
    /// Referencia al implementor (Bridge): conecta la abstracción con la implementación.
    /// Este es el "puente" que permite que ambas jerarquías varíen independientemente.
    /// </summary>
    protected IDisplayFormatter _displayFormatter;

    public string Text { get; set; } = string.Empty;

    protected ReaderApp(IDisplayFormatter displayFormatter)
    {
        _displayFormatter = displayFormatter;
    }

    /// <summary>
    /// Método abstracto que define la operación de alto nivel.
    /// Las clases derivadas implementarán este método delegando en el implementor.
    /// </summary>
    public abstract string Display();
}

/// <summary>
/// Implementación concreta (ConcreteImplementor) que muestra texto normal.
/// Parte de la jerarquía de implementación que puede extenderse independientemente.
/// </summary>
public class NormalDisplay : IDisplayFormatter
{
    public string Display(string text)
    {
        return text;
    }
}

/// <summary>
/// Implementación concreta que muestra texto en reversa.
/// Otra variante de la implementación que demuestra cómo se puede extender la funcionalidad.
/// </summary>
public class ReverseDisplay : IDisplayFormatter
{
    public string Display(string text)
    {
        return new string(text.Reverse().ToArray());
    }
}

/// <summary>
/// Abstracción refinada (RefinedAbstraction) para Windows 7.
/// Extiende la funcionalidad de ReaderApp añadiendo comportamiento específico de la plataforma.
/// Puede combinarse con cualquier implementación de IDisplayFormatter.
/// </summary>
public class Windows7 : ReaderApp
{
    public Windows7(IDisplayFormatter displayFormatter) : base(displayFormatter)
    {
    }

    /// <summary>
    /// Implementación específica que delega el formateo al implementor.
    /// Añade contexto específico de Windows 7 antes de delegar.
    /// </summary>
    public override string Display()
    {
        return _displayFormatter.Display("Aplicación utilizada desde window 7 \n" + Text);
    }
}

/// <summary>
/// Abstracción refinada para Windows 10.
/// Otra extensión de ReaderApp con comportamiento específico de plataforma.
/// Demuestra cómo la abstracción puede variar independientemente de la implementación.
/// </summary>
public class Windows10 : ReaderApp
{
    public Windows10(IDisplayFormatter displayFormatter) : base(displayFormatter)
    {
    }

    /// <summary>
    /// Implementación específica para Windows 10.
    /// Similar a Windows7 pero con texto diferente, mostrando la flexibilidad del patrón.
    /// </summary>
    public override string Display()
    {
        return _displayFormatter.Display("Aplicación utilizada desde window 10 \n" + Text);
    }
}