namespace SpaceGame.Tests.Integration.PhysicalBehaviourTests
{
    [IntegrationTest.DynamicTest("PhysicalBehaviourTests")]
    class it_returns_the_object_location : physical_behaviour_test
    {
        void Test ()
        {
            Location location = physical.GetCurrentLocation();

            AssertThat(location.position == physical_object.transform.position);
            AssertThat(location.orientation == physical_object.transform.up);
        }
    }
}

