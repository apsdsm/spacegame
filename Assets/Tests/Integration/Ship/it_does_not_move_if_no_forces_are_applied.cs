using UnityEngine;

namespace SpaceGame.Tests.Integration.ShipTests
{

    [IntegrationTest.DynamicTest( "ShipTests" )]
    class it_does_not_move_if_no_forces_are_applied : ship_test
    {
        void TestEachFrame ()
        {
            if ( TotalTime > 1.0f )
            {
                AssertThat( ship_object.transform.position.sqrMagnitude == 0 );
            }
        }
    }
}

