using UnityEngine;

namespace SpaceGame.Tests.Integration.ShipTests
{

    [IntegrationTest.DynamicTest( "ShipTests" )]
    class it_can_add_longitudinal_thrust : ship_test
    {
        void TestEachFrame ()
        {
            ship.AddLongitudinalThrust( 1.0f );

            float distanceTranvelled = ship_object.transform.position.sqrMagnitude;

            if ( distanceTranvelled > 0)
            {
                Pass();
            }
        }
    }
}

