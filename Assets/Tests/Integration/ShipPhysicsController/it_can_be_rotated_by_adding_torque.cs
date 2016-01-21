using UnityEngine;

namespace SpaceGame.Tests.Integration.ShipPhysicsControllerTests
{
    [IntegrationTest.DynamicTest( "ShipPhysicsControllerTests" )]
    class it_can_be_rotated_by_adding_torque : ship_physics_controller_test
    {
        Vector3 startFacing;

        public override void SetUp ()
        {
            base.SetUp();

            startFacing = ship_object.transform.forward;
        }

        void TestEachFrame ()
        {
            ship_controller.AddRelativeTorque( ship_object.transform.up );

            float angleTurned = Vector3.Angle( startFacing, ship_object.transform.forward );

            if ( angleTurned != 0 )
            {
                Pass();
            }
        }
    }
}
