using Patterns.Creational.Prototype;
using Shouldly;
using System;
using Xunit;

namespace PatternsTests;

public class PrototypeTest
{
    [Fact]
    public void CreatePrototype_Clonable_ShouldBeOk()
    {
        var macbookPro = new Patterns.Creational.Prototype.Clonable.Product("MacBook Pro", 
            new Patterns.Creational.Prototype.Clonable.Category("Computers"));
        var dell = (Patterns.Creational.Prototype.Clonable.Product)macbookPro.Clone();
        dell.Name = "Dell";
        dell.Category.Name = "Notebooks";
        macbookPro.Name.ShouldBe("MacBook Pro");
        macbookPro.Category.Name.ShouldBe("Computers");
        dell.Name.ShouldBe("Dell");
        dell.Category.Name.ShouldBe("Notebooks");
    }

    [Fact]
    public void CreatePrototype_DeepCopy_ShouldBeOk()
    {
        var macbookPro = new Patterns.Creational.Prototype.DeepCopy.Product("MacBook Pro", new Patterns.Creational.Prototype.DeepCopy.Category("Computers"));
        var dell = macbookPro.DeepCopy();
        dell.Category.Name = "Notebooks";
        dell.Name = "Dell";

        macbookPro.Name.ShouldBe("MacBook Pro");
        macbookPro.Category.Name.ShouldBe("Computers");
        dell.Name.ShouldBe("Dell");
        dell.Category.Name.ShouldBe("Notebooks");
    }

    [Fact]
    public void CreatePrototype_Serialization_ShouldBeOk()
    {
        var macbookPro = new Product("MacBook Pro", new Category("Computers"));
        var dell = macbookPro.DeepCopy();
        dell.Category.Name = "Notebooks";
        dell.Name = "Dell";
        macbookPro.Name.ShouldBe("MacBook Pro");
        macbookPro.Category.Name.ShouldBe("Computers");
        dell.Name.ShouldBe("Dell");
        dell.Category.Name.ShouldBe("Notebooks");
    }
}