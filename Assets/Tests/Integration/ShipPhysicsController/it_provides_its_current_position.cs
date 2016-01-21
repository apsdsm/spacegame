using UnityEngine;

namespace SpaceGame.Tests.Integration.ShipPhysicsControllerTests
{
    [IntegrationTest.DynamicTest( "ShipPhysicsControllerTests" )]
    class it_provides_its_current_position : ship_physics_controller_test
    {
        void TestEachFrame ()
        {
            Vector3 newPositon = new Vector3( 10.0f, 10.0f, 10.0f );

            ship_object.transform.position = newPositon;

            AssertThat( ship_controller.Position == newPositon, "did not provide the right position" );
        }
    }
}
