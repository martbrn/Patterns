using Patterns.Estructural.Adapter;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class AdapterTest
{
    [Fact]
    public void CreateAdapter_ShouldBeOk()
    {
        var xmlConverter = new XmlConverter();
        var adapter = new XmlToJsonAdapter(xmlConverter);
        var result = adapter.ConvertXmlToJson();
        result.ShouldNotBeNullOrEmpty();
    }
}
