using UnityEngine;

namespace SpaceGame.Tests.Integration.PlanetTests
{
    [IntegrationTest.DynamicTest( "PlanetTests" )]
    class it_provides_a_random_position_a_set_distance_above_the_surface : planet_test
    {
        void Test ()
        {
            Vector3 position = planet.GetRandomPosition( 10.0f );

            AssertThat( position != Vector3.zero );
        }
    }
}
