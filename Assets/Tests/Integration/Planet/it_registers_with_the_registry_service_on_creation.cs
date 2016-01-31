
using UnityEngine;
using SpaceGame.Tests.Fakes;
using SpaceGame.Interfaces;
using Fletch;

namespace SpaceGame.Tests.Integration.PlanetTests
{
    [IntegrationTest.DynamicTest("PlanetTests")]
    class it_registers_with_the_registry_service_on_creation : planet_test
    {
        void Test ()
        {
            AssertThat(registry.registerCalled == 1, "nothing registered with registry");
            AssertThat(registry.registerReceivedIdentifier == "Planet", "registered with wrong identifier");
            AssertThat(registry.registerReceivedType == typeof(IPlanet), "registered with wrong type");
            AssertThat(registry.registerReceivedReference == (object)planet, "registered with wrong reference");
        }
    }
}
