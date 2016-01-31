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
            planet.getRandomPositionReturns = Vector3.one;
            registry.lookUpReturns = planet;
            factory.createEnemyShipReturns = enemy;
        }

        void TestEachFrame ()
        {
            if (TotalTime > 0.7f)
            {
                AssertThat(registry.lookUpCalled == 1, "called registry more than once.");
                AssertThat(planet.getRandomPositionReceivedDistanceFromSurface == 10.0f, "did not pass the correct height to planet");
                AssertThat(enemy.setPositionCalled == 1, "did not set enemy position");
                AssertThat(enemy.setPositionPositionValue == Vector3.one, "set enemy at incorrect position");
            }
        }
    }

}