using SpaceGame.Interfaces;
using SpaceGame.Tests.Fakes;
using Fletch;

namespace SpaceGame.Tests.Integration.ShipTests
{

    [IntegrationTest.DynamicTest( "ShipTests" )]
    class it_registers_with_the_controller_service_on_creation : ship_test
    {

        private PCShipControllerFake controller;

        public override void SetUp ()
        {
            controller = (PCShipControllerFake)IOC.Resolve<IShipController>();
            controller.registerCalled = 0;

            base.SetUp();
        }

        void Test ()
        {
            AssertThat( controller.registerCalled == 1 );
        }
    }
}

