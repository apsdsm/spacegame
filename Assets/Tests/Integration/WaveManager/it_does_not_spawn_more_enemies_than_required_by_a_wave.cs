using UnityEngine;
using SpaceGame.Actors;
using SpaceGame.Interfaces;
namespace SpaceGame.Tests.Integration.WaveManagerTests
{
    [IntegrationTest.DynamicTest("WaveManagerTests")]
    class it_does_not_spawn_more_enemies_than_required_by_wave : test_case
    {
        public override void SetUp ()
        {
            base.SetUp();

            wave_manager.spawnCooldown = 0.5f;
            wave_manager.enemiesInWave = 1;
        }

        void TestEachFrame ()
        {
            if (TotalTime > 1.1f)
            {
                AssertThat(factory.createEnemyShipCalled == 1, "created more enemies than required");
            }
        }
    }

}