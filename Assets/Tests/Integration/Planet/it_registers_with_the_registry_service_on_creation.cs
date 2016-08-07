
using UnityEngine;
using SpaceGame.Tests.Fakes;
using SpaceGame.Interfaces;
using Fletch;
using Fletch.Fakes;

namespace SpaceGame.Tests.Integration.PlanetTests
{
    [IntegrationTest.DynamicTest("PlanetTests")]
    class it_registers_with_the_registry_service_on_creation : planet_test
    {
        public override void SetUp ()
        {
            registry = (RegistryServiceFake)IOC.Resolve<IRegistryService>();
            registry.Expects("Register").ToBeCalled(1).With("Planet", planet);

            base.SetUp();
        }

        void Test ()
        {
            AssertThat(registry.MeetsExpectations());
        }
    }
}
