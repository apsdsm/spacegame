using UnityEngine;

namespace SpaceGame.Tests.Integration.PhysicalBehaviourTests
{
    [IntegrationTest.DynamicTest("PhysicalBehaviourTests")]
    class it_moves_to_a_new_location : physical_behaviour_test
    {
        void Test ()
        {
            Location location = new Location() { position = Vector3.one, orientation = Vector3.one };
            
            AssertThat(physical_object.transform.position == Vector3.one);
            AssertThat(physical_object.transform.up == Vector3.one);
        }
    }
}
