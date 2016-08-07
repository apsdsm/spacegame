using SpaceGame.Interfaces;
using SpaceGame.Tests.Fakes;
using UnityEngine;

namespace SpaceGame.Tests.Integration.CollectableFactoryTests
{
    [IntegrationTest.DynamicTest("collectable_factory_test_scene")]
    class it_spawns_wave_actors : collectable_factory_test
    {
        void Test ()
        {
            ICollectable result = collectable_factory.CreateCoin();

            AssertThat( result != null, "created object was null." );

        }
    }
}
