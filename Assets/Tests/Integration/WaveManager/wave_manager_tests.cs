using UnityEngine;
using SpaceGame.Actors;
using SpaceGame.Interfaces;
using SpaceGame.Tests.Fakes;
using Flexo;
using Fletch;
using Fletch.Fakes;
using TestHelpers;

namespace SpaceGame.Tests.Integration.WaveManagerTests
{
    public class test_case : UTestCase
    {
        // sut
        protected GameObject wave_manager_object;
        protected WaveManager wave_manager;

        // fakes
        protected PhysicalFactoryFake factory;
        protected RegistryServiceFake registry;
        protected PlanetFake planet;
        protected PhysicalFake enemy;

        public override void SetUp ()
        {
            base.SetUp();

            planet = new PlanetFake();

            enemy = new PhysicalFake();

            factory = (PhysicalFactoryFake)IOC.Resolve<IPhysicalFactory>();

            factory.createEnemyShipReturns = enemy;

            registry = (RegistryServiceFake)IOC.Resolve<IRegistryService>();

            registry.lookUpReturns = planet;

            wave_manager_object = new FlexoGameObject("wave_manager").With<WaveManager>(out wave_manager);
        }

        public override void TearDown ()
        {
            base.TearDown();

            // destroy objects
            GameObject.Destroy(wave_manager_object);

            // reset fakes
            factory.ResetFake();
            registry.ResetFake();
            enemy.ResetFake();
            planet.ResetFake();
        }
    }
}
