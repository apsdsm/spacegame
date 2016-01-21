using UnityEngine;

namespace SpaceGame.Tests.Integration.ShipPhysicsControllerTests
{
    [IntegrationTest.DynamicTest( "ShipPhysicsControllerTests" )]
    class it_does_not_move_if_no_forces_are_applied : ship_physics_controller_test
    {
        void TestEachFrame ()
        {
            if ( Frame == 100 )
            {
                AssertThat( ship_object.transform.position == Vector3.zero, "ship moved, but should be immobile" );
            }
        }
    }
}
