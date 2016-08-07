using UnityEngine;

namespace SpaceGame.Tests.Integration.PhysicalBehaviourTests
{
    [IntegrationTest.DynamicTest( "PhysicalBehaviourTests" )]
    class it_adds_force_to_the_object : physical_behaviour_test
    {
        void TestEachFrame ()
        {
            physical.AddForce( Vector3.forward );

            if ( physical_object.transform.position != Vector3.zero )
            {
                AssertSameDirection( physical.transform.position, Vector3.forward );
            }
        }
    }
}

