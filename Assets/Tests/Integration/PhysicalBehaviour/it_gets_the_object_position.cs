namespace SpaceGame.Tests.Integration.PhysicalBehaviourTests
{
    [IntegrationTest.DynamicTest("PhysicalBehaviourTests")]
    class it_gets_the_object_position : physical_behaviour_test
    {
        void Test ()
        {
            AssertThat( physical.Position == physical_object.transform.position );
        }
    }
}

