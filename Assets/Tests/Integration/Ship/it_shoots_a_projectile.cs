using UnityEngine;
using SpaceGame.Tests.Fakes;
using SpaceGame.Interfaces;
using Fletch;
using TestHelpers;
using Fletch.Fakes;

namespace SpaceGame.Tests.Integration.ShipTests
{
    [IntegrationTest.DynamicTest("ShipTests")]
    class it_shoots_a_projectile : ship_test
    {

        RegistryServiceFake registry;
        ShootableFactoryFake factory;
        ShootableFake shootable;
        PlanetFake planet;

        public override void SetUp ()
        {
            base.SetUp();

            planet = new PlanetFake();
            planet.Expects("CoreLocation").AndReturns<Vector3>(Vector3.zero);

            registry = (RegistryServiceFake)IOC.Resolve<IRegistryService>();
            registry.Expects("LookUp").With("Planet").AndReturns<IPlanet>(planet);

            shootable = new ShootableFake();
            shootable.Expects("Shoot").ToBeCalled(1).With(ship_object.transform.forward, ship_object.transform.position, Vector3.zero);

            factory = (ShootableFactoryFake)IOC.Resolve<IShootableFactory>();
            factory.Expects("CreatePlayerBullet").ToBeCalled(1);
        }

        void Test ()
        {
            ship.Shoot();

            AssertThat(factory.MeetsExpectations());
            AssertThat(shootable.MeetsExpectations());
            AssertThat(registry.MeetsExpectations());
            AssertThat(planet.MeetsExpectations());
        }
    }
}

