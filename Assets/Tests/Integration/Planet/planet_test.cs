using UnityEngine;
using SpaceGame.Actors;
using Fletch;
using Fletch.Fakes;
using TestHelpers;

namespace SpaceGame.Tests.Integration.PlanetTests
{
    class planet_test : UTestCase
    {
        protected GameObject planet_object;
        protected Planet planet;

        // fakes
        protected RegistryServiceFake registry;

        public override void SetUp ()
        {
            base.SetUp();

            planet_object = GameObject.Find( "Planet" );
            planet = planet_object.GetComponent<Planet>();

            registry = (RegistryServiceFake)IOC.Resolve<IRegistryService>();

        }

        public override void TearDown ()
        {
            base.TearDown();
        }
    }
}
