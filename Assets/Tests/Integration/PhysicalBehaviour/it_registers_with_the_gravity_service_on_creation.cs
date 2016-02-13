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
            gravity.registerCalled = 0;

            base.SetUp();
        }

        void Test ()
        {
            AssertThat( gravity.registerCalled == 1 );
        }
    }
}

