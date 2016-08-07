using UnityEngine;

namespace SpaceGame.Tests.Integration.PlanetTests
{
    [IntegrationTest.DynamicTest( "PlanetTests" )]
    class it_provides_a_random_spawn_point_above_the_surface : planet_test
    {
        void Test ()
        {
            Location spawn_point = planet.GetRandomSpawnPoint();

            AssertThat(spawn_point.position != Vector3.zero);
            AssertThat(spawn_point.orientation != Vector3.zero);
        }
    }
}
