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
        protected PhysicalFactoryFake physical_factory;
        protected CollectableFactoryFake collectable_factory;
        protected RegistryServiceFake registry;
        protected PlanetFake planet;
        protected PhysicalFake enemy;
        protected CollectableFake collectable;

        public override void SetUp ()
        {
            base.SetUp();

            planet = new PlanetFake();
            enemy = new PhysicalFake();
            collectable = new CollectableFake();

            physical_factory = (PhysicalFactoryFake)IOC.Resolve<IPhysicalFactory>();
            collectable_factory = (CollectableFactoryFake)IOC.Resolve<ICollectableFactory>();
            registry = (RegistryServiceFake)IOC.Resolve<IRegistryService>();

            wave_manager_object = new FlexoGameObject("wave_manager").With<WaveManager>(out wave_manager);
           
        }

        public override void TearDown ()
        {
            base.TearDown();

            GameObject.Destroy(wave_manager_object);

            physical_factory.Done();
            collectable_factory.Done();
            registry.Done();

            //enemy.Done();
            //collectable.Done();
            //planet.Done();
        }
    }
}
