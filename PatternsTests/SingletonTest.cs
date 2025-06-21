using Patterns.Creational;
using Shouldly;
using Xunit;

namespace PatternsTests;

public class SingletonTest
{
    [Fact]
    public void ShouldReturnSameInstance_ShouldBeOk()
    {
        var instance1 = Singleton.Instance;
        var instance2 = Singleton.Instance;
        instance1.ShouldBe(instance2);
    }

    [Fact]
    public void Singleton_ShouldOnlyCreateOneInstance_EvenWithMultipleThreads_ShouldBeOk()
    {
        const int threadCount = 50;
        Singleton[] instances = new Singleton[threadCount];

        Parallel.For(0, threadCount, i =>
        {
            instances[i] = Singleton.Instance;
        });

        // Verificamos que todas las referencias sean la misma instancia
        for (int i = 1; i < threadCount; i++)
            instances[0].ShouldBe(instances[i]);
    }
}