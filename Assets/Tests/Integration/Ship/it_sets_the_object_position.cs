using UnityEngine;
using TestHelpers;

namespace SpaceGame.Tests.Integration.ShipTests
{
    [IntegrationTest.DynamicTest( "ShipTests" )]
    class it_sets_the_object_position : ship_test
    {
        void Test ()
        {
            ship.SetPosition( Vector3.one );

            AssertThat( ship_object.transform.position == Vector3.one );
        }
    }
}

