using Patterns.Behavior;
using Xunit;

namespace PatternsTests;

public class ObserverTest
{
    [Fact]
    public void CreateObserver_ShouldBeOk()
    {
        var limon = new Limon(0.82);
        var restaurantPaella = new Restaurant("La Paella", 0.77);
        var restaurantGloria = new Restaurant("La Gloria", 0.74);
        var restaurantConsentidos = new Restaurant("Los Consentidos", 0.75);
        limon.Attach(restaurantPaella);
        limon.Attach(restaurantGloria);
        limon.Attach(restaurantConsentidos);

        // Fluctuacion de precios
        limon.PricePerKg = 0.79;
        limon.PricePerKg = 0.76;
        limon.PricePerKg = 0.74;
        limon.PricePerKg = 0.81;
        restaurantPaella._purchaseThreshold = 0.77;
        restaurantGloria._purchaseThreshold = 0.74;
        restaurantConsentidos._purchaseThreshold = 0.75;
    }
}