using UnityEngine;

namespace SpaceGame.Tests.Integration.PhysicalBehaviourTests
{
    [IntegrationTest.DynamicTest("PhysicalBehaviourTests")]
    class it_sets_the_object_position : physical_behaviour_test
    {
        void Test ()
        {
            physical.Position = ( Vector3.one );

            AssertThat( physical_object.transform.position == Vector3.one );
        }
    }
}

