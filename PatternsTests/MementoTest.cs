using Patterns.Behavior;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class MementoTest
{
    [Fact]
    public void CreateMemento_ShouldBeOk()
    {
        var account = new Account(100);
        account.Deposit(20);
        account.Deposit(30);

        account.Balance.ShouldBe(150);
        account.Undo();
        account.Balance.ShouldBe(120);
        account.Undo();
        account.Balance.ShouldBe(100);
        account.Redo();
        account.Balance.ShouldBe(120);
    }
}