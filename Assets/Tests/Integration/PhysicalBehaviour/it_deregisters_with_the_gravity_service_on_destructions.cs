using SpaceGame.Interfaces;
using SpaceGame.Tests.Fakes;
using Fletch;

namespace SpaceGame.Tests.Integration.PhysicalBehaviourTests
{

    [IntegrationTest.DynamicTest("PhysicalBehaviourTests")]
    class it_deregisters_with_the_gravity_service_on_destructions : physical_behaviour_test
    {
        private GravityServiceFake gravity;

        public override void SetUp ()
        {
            base.SetUp();

            gravity = (GravityServiceFake)IOC.Resolve<IGravityService>();

            gravity.Expects("Resolve").ToBeCalled(1);

            Destroy(physical_object);
        }

        void TestEachFrame ()
        {
            if (gravity.MeetsExpectations()) {
                Pass();
            }
        }
    }
}