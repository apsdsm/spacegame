using UnityEngine;

namespace SpaceGame.Tests.Integration.ShipTests
{
    [IntegrationTest.DynamicTest( "ShipTests" )]
    class it_can_add_rotational_thrust : ship_test
    {
        Vector3 initialFacing;

        public override void SetUp ()
        {
            base.SetUp();

            initialFacing = ship_object.transform.forward;
        }

        void TestEachFrame ()
        {
            ship.AddRotationalThrust( 1.0f );

            float degreesTurned = Vector3.Angle( initialFacing, ship_object.transform.forward );

            if ( degreesTurned > 0 )
            {
                Pass();
            }
        }
    }
}

