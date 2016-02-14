using UnityEngine;
using SpaceGame.Tests.Fakes;

namespace SpaceGame.Tests.Integration.WaveManagerTests
{
    [IntegrationTest.DynamicTest("WaveManagerTests")]
    class it_spawns_enemies_above_the_surface_of_the_planet : test_case
    {

        public override void SetUp ()
        {
            base.SetUp();

            wave_manager.spawnCooldown = 0.5f;
            wave_manager.enemiesInWave = 1;
            wave_manager.spawnHeight = 10.0f;
            planet.getRandomPositionReturns = new SpawnPoint() { position = Vector3.up, orientation = Vector3.up };
            registry.lookUpReturns = planet;
            factory.createEnemyShipReturns = enemy;
        }

        void TestEachFrame ()
        {
            if (TotalTime > 0.7f)
            {
                AssertThat(registry.lookUpCalled == 1, "called registry more than once.");
                AssertThat(planet.getRandomPositionReceivedDistanceFromSurface == 10.0f, "did not pass the correct height to planet");
                AssertThat(enemy.positionSet == 1, "did not set enemy position");
                AssertThat(enemy.positionSetWith == Vector3.up, "set enemy at incorrect position");
                AssertThat(enemy.upSet == 1, "did not set enemy orientation");
                AssertThat(enemy.upSetWith == Vector3.up, "set enemy with incorrect orientation");
            }
        }
    }

}