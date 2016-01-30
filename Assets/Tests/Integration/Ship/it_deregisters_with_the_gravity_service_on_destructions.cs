using SpaceGame.Interfaces;
using SpaceGame.Tests.Fakes;
using Fletch;

namespace SpaceGame.Tests.Integration.ShipTests
{

    [IntegrationTest.DynamicTest( "ShipTests" )]
    class it_deregisters_with_the_gravity_service_on_destructions : ship_test
    {

        private GravityServiceFake gravity;

        public override void SetUp ()
        {
            base.SetUp();

            gravity = ( GravityServiceFake ) IOC.Resolve<IGravityService>();
            gravity.deregisterCalled = 0;

            Destroy( ship_object );
        }

        void TestEachFrame ()
        {
            if ( gravity.deregisterCalled == 1 )
            {
                Pass();
            }
        }

        public override void TearDown ()
        {
            // don't destroy the ship because it was destroyed as a part of this test
        }
    }
}