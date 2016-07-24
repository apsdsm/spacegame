using SpaceGame.Interfaces;
using SpaceGame.Tests.Fakes;
using Fletch;

namespace SpaceGame.Tests.Integration.ShipTests
{

    [IntegrationTest.DynamicTest("ShipTests")]
    class it_deregisters_with_the_controller_service_on_destruction : ship_test
    {

        private PCShipControllerFake controller;

        public override void SetUp ()
        {
            base.SetUp();

            controller = (PCShipControllerFake)IOC.Resolve<IShipController>();

            controller.Expects("Deregister").ToBeCalled(1);

            Destroy(ship_object);
        }

        void TestEachFrame ()
        {
            if (controller.MeetsExpectations()) {
                Pass();
            }
        }

        public override void TearDown ()
        {
            // don't destroy the ship because it was destroyed as a part of this test

            controller.Done();
        }
    }
}
