using Patterns.Behavior;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class CommandTest
{
    [Fact]
    public void CreateAdapter_ShouldBeOk()
    {
        var modifyPrice = new ModifyPrice();
        var product = new Product("IPhone", 5000);
        var productCommand = new ProductCommand(product, PriceAction.Increase, 100);

        modifyPrice.SetCommand(productCommand);
        modifyPrice.Invoke();

        var productCommand1 = new ProductCommand(product, PriceAction.Decrease, 30000);
        modifyPrice.SetCommand(productCommand1);
        modifyPrice.Invoke();
        product.ToString().ShouldBe($"El precio actual de IPhone es 5100");
        modifyPrice.Undo();
        product.ToString().ShouldBe($"El precio actual de IPhone es 5000");
    }
}