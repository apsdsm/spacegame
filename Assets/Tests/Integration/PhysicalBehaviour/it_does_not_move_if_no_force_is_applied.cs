namespace SpaceGame.Tests.Integration.PhysicalBehaviourTests
{

    [IntegrationTest.DynamicTest("PhysicalBehaviourTests")]
    class it_does_not_move_if_no_forces_are_applied : physical_behaviour_test
    {
        void TestEachFrame ()
        {
            if (TotalTime > 1.0f)
            {
                AssertThat(physical_object.transform.position.sqrMagnitude == 0);
            }
        }
    }
}

