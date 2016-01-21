using UnityEngine;

namespace SpaceGame.Tests.Integration.ShipPhysicsControllerTests
{
    [IntegrationTest.DynamicTest( "ShipPhysicsControllerTests" )]
    class it_can_be_moved_by_adding_force : ship_physics_controller_test
    {
        Vector3 startPos;

        public override void SetUp ()
        {
            base.SetUp();

            startPos = ship_object.transform.position;
        }

        void TestEachFrame ()
        {
            ship_controller.AddRelativeForce( ship_object.transform.forward );

            float distanceTravelled = ( ship_object.transform.position - startPos ).magnitude;

            if ( distanceTravelled != 0.0f )
            {
                Pass();
            }
        }
    }
}
