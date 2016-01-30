using UnityEngine;
using SpaceGame.Actors;
using Flexo;
using TestHelpers;

namespace SpaceGame.Tests.Integration.PlanetTests
{
    class planet_test : UTestCase
    {
        protected GameObject planet_object;
        protected Planet planet;

        public override void SetUp ()
        {
            base.SetUp();

            planet_object = GameObject.Find( "Planet" );
            planet = planet_object.GetComponent<Planet>();

        }
    }
}
