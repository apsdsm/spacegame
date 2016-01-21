using UnityEngine;
using TestHelpers;
using SpaceGame.Reporters;
using Flexo;

namespace SpaceGame.Tests.Integration.SizeReporterTests
{

    class size_reporter_test : UTestCase
    {
        // sut
        protected PlanetSizeReporter size_reporter;

        // game object
        protected GameObject game_object;

        // collider
        protected SphereCollider sphere_collider;

        /// <summary>
        /// Set up new ship object.
        /// </summary>
        override public void SetUp ()
        {
            game_object = GameObject.Find( "SUT" );
            size_reporter = game_object.GetComponent<PlanetSizeReporter>();
            sphere_collider = game_object.GetComponent<SphereCollider>();
        }
    }
}
