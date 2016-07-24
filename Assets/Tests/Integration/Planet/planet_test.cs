using UnityEngine;
using SpaceGame.Actors;
using Flexo;
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

            planet_object = new FlexoGameObject("planet").With<Planet>(out planet);

        }

        public override void TearDown ()
        {
            base.TearDown();
        }
    }
}
