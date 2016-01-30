using UnityEngine;

namespace SpaceGame.Tests.Integration.ShipTests
{
    [IntegrationTest.DynamicTest( "ShipTests" )]
    class it_adds_force_to_the_object : ship_test
    {
        void TestEachFrame ()
        {
            ship.AddForce( Vector3.forward );

            if ( ship_object.transform.position != Vector3.zero )
            {
                AssertSameDirection( ship.transform.position, Vector3.forward );
            }
        }
    }
}

