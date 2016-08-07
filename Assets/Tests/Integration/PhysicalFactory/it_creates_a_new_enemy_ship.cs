using UnityEngine;
using SpaceGame.Interfaces;

namespace SpaceGame.Tests.Integration.ShipFactoryTests
{

    [IntegrationTest.DynamicTest( "PhysicalFactoryTests" )]
    class it_creates_a_new_enemy_ship : physical_factory_test
    {
        void Test ()
        {
            IPhysical result = ship_factory.CreateEnemyShip();

            AssertThat( result != null, "created object was null." );

        }
    }
}
