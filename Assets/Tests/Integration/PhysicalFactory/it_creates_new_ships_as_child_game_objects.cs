using UnityEngine;

namespace SpaceGame.Tests.Integration.ShipFactoryTests
{

    [IntegrationTest.DynamicTest( "PhysicalFactoryTests" )]
    class it_creates_new_ships_as_child_game_objects : physical_factory_test
    {
        void Test ()
        {
            ship_factory.CreatePlayerShip();
            
            AssertThat( ship_factory.transform.childCount != 0, "should have children." );
        }
    }
}

