using UnityEngine;
using SpaceGame.Interfaces;

namespace SpaceGame.Tests.Integration.ShipFactoryTests
{

    [IntegrationTest.DynamicTest( "ShipFactoryTests" )]
    class it_creates_a_new_enemy_ship : ship_factory_test
    {
        void Test ()
        {
            IPhysical result = ship_factory.CreateEnemyShip();

            AssertThat( result != null, "created object was null" );
        }
    }
}
