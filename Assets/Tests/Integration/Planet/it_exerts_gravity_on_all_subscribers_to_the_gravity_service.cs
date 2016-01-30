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

        public override void SetUp ()
        {
            base.SetUp();

            gravity = (GravityServiceFake)IOC.Resolve<IGravityService>();
        }

        void Test ()
        {
            gravity.getTargetsCalled = 0;

            planet_object.SendMessage("Update");

            AssertThat(gravity.getTargetsCalled == 1);
            AssertThat(gravity.physicalFake.addForceCalled == 1);
        }
    }
}
