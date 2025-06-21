using System.Xml.Linq;
using Newtonsoft.Json;

namespace Patterns.Estructural.Adapter;

// ======================================================================
// PATRÓN ADAPTER (ADAPTADOR)
// ======================================================================
/// Permite que interfaces incompatibles trabajen juntas.
/// Convierte la interfaz de una clase en otra interfaz que los clientes esperan.


/// <summary>
/// Clase de modelo de datos común utilizada por diferentes componentes.
/// </summary>
public class Product
{
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }

    public Product() { }
    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }
}

/// <summary>
/// Proveedor de datos que simula una fuente de información.
/// </summary>
public static class ProductDataProvider
{
    public static List<Product> GetData() =>
        new()
        {
            new ("IPhone", 5000),
            new ("Xiami Mi 2", 100),
            new ("Samsung s9", 4000)
        };
}

/// <summary>
/// Clase existente (Adaptee) que genera datos en formato XML.
/// Esta clase ya existe y no podemos modificarla, pero necesitamos usar su funcionalidad.
/// Su interfaz es incompatible con lo que necesita el cliente.
/// </summary>
public class XmlConverter
{
    /// <summary>
    /// Método que devuelve datos en formato XML.
    /// Esta es la funcionalidad existente que queremos adaptar.
    /// </summary>
    /// <returns>Documento XML con los productos</returns>
    public XDocument GetXml()
    {
        var xDocument = new XDocument();
        var xElement = new XElement("Productos");
        var xAttributes = ProductDataProvider.GetData()
            .Select(m => new XElement("Producto",
            new XAttribute("Nombre", m.Name), new XAttribute("Precio", m.Price)));
        xElement.Add(xAttributes);
        xDocument.Add(xElement);
        return xDocument;
    }
}

/// <summary>
/// Interfaz que define lo que el cliente espera (Target).
/// El cliente quiere convertir XML a JSON, pero XmlConverter no ofrece esta funcionalidad.
/// </summary>
public interface IXmlToJson
{
    string ConvertXmlToJson();
}

/// <summary>
/// Clase Adapter que hace compatible XmlConverter con la interfaz IXmlToJson.
/// Adapta la interfaz de XmlConverter para que sea compatible con lo que espera el cliente.
/// Implementa el patrón Object Adapter (composición).
/// </summary>
public class XmlToJsonAdapter : IXmlToJson
{
    /// <summary>
    /// Referencia al objeto que queremos adaptar (Adaptee).
    /// </summary>
    private XmlConverter _xmlConverter;

    public XmlToJsonAdapter(XmlConverter xmlConverter)
    {
        _xmlConverter = xmlConverter;
    }

    /// <summary>
    /// Método que implementa la interfaz esperada por el cliente.
    /// Internamente usa el XmlConverter (adaptee) y adapta su salida al formato requerido.
    /// Realiza la traducción entre las interfaces incompatibles.
    /// </summary>
    /// <returns>Datos en formato JSON convertidos desde XML</returns>
    public string ConvertXmlToJson()
    {
        // 1. Usa el método del adaptee para obtener XML
        var xmlData = _xmlConverter.GetXml();

        // 2. Convierte el XML a objetos Product
        var products = xmlData
            .Element("Productos")!
            .Elements("Producto")
            .Select(m => new Product
            {
                Name = m.Attribute("Nombre")!.Value,
                Price = int.Parse(m.Attribute("Precio")!.Value)
            });

        // 3. Usa otro conversor para obtener JSON (delegación)
        return new JsonConverter(products).ConvertToJson();
    }
}

/// <summary>
/// Clase auxiliar que convierte objetos a JSON.
/// Forma parte de la solución del adapter, encapsula la lógica de conversión a JSON.
/// </summary>
public class JsonConverter
{
    private IEnumerable<Product> _productData;

    public JsonConverter(IEnumerable<Product> productData)
    {
        _productData = productData;
    }

    /// <summary>
    /// Convierte los datos de productos a formato JSON.
    /// </summary>
    /// <returns>String JSON formateado</returns>
    public string ConvertToJson()
    {
        var result = JsonConvert.SerializeObject(_productData, Formatting.Indented);
        return result;
    }
}