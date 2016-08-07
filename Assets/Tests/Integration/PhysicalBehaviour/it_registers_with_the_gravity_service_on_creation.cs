using SpaceGame.Interfaces;
using SpaceGame.Tests.Fakes;
using Fletch;

namespace SpaceGame.Tests.Integration.PhysicalBehaviourTests
{

    [IntegrationTest.DynamicTest("PhysicalBehaviourTests")]
    class it_registers_with_the_gravity_service_on_creation : physical_behaviour_test
    {

        private GravityServiceFake gravity;

        public override void SetUp ()
        {
            gravity = ( GravityServiceFake ) IOC.Resolve<IGravityService>();

            gravity.Expects("Register").ToBeCalled(1);

            base.SetUp();
        }

        void Test ()
        {
            AssertThat(gravity.MeetsExpectations() );
        }
    }
}

