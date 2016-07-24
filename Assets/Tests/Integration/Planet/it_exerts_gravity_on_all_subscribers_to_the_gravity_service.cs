using UnityEngine;
using SpaceGame.Tests.Fakes;
using SpaceGame.Interfaces;
using Fletch;

namespace SpaceGame.Tests.Integration.PlanetTests
{
    [IntegrationTest.DynamicTest("PlanetTests")]
    class it_exerts_gravity_on_all_subscribers_to_the_gravity_service : planet_test
    {
        GravityServiceFake gravity;
        PhysicalFake target;

        public override void SetUp ()
        {
            base.SetUp();

            target = new PhysicalFake();
            target.Expects("AddForce").ToBeCalled(1);

            gravity = (GravityServiceFake)IOC.Resolve<IGravityService>();
            gravity.Expects("Targets").ToBeCalled(1).AndReturns(new IPhysical[] { target });


        }

        void Test ()
        {
            planet_object.SendMessage("Update");

            AssertThat(gravity.MeetsExpectations());
            AssertThat(target.MeetsExpectations());
        }
    }
}
