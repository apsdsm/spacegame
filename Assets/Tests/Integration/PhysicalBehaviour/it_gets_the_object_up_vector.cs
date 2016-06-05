namespace SpaceGame.Tests.Integration.PhysicalBehaviourTests
{
    [IntegrationTest.DynamicTest("PhysicalBehaviourTests")]
    class it_gets_the_object_up_vector : physical_behaviour_test
    {
        void Test ()
        {
            AssertThat(physical.Up == physical_object.transform.up);
        }
    }
}

