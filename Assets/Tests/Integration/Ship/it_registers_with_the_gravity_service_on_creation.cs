using SpaceGame.Interfaces;
using SpaceGame.Tests.Fakes;
using Fletch;

namespace SpaceGame.Tests.Integration.ShipTests
{

    [IntegrationTest.DynamicTest( "ShipTests" )]
    class it_registers_with_the_gravity_service_on_creation : ship_test
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

