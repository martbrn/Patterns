using Patterns.Behavior;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PatternsTests;

public class NullObjectTest
{
    [Fact]
    public void CreateNullObjectTest_ShouldBeOk()
    {
        var studentOrder = new Order(new StudentDiscount(), 50);
        studentOrder.GetDiscout().ShouldBe(50 * 0.5);

        var friendOrder = new Order(new FriendDiscount(), 100);
        friendOrder.GetDiscout().ShouldBe(100 * 0.6);

        var noDiscountOrder = new Order(new NullDiscount(), 100);
        noDiscountOrder.GetDiscout().ShouldBe(0);

        var order = new Order();
        var orderByProduct = order.GetOrderByProducyName("Producto");
        orderByProduct.ShouldNotBeNull();
    }
}