using SpaceGame.Interfaces;
using SpaceGame.Tests.Fakes;
using UnityEngine;

namespace SpaceGame.Tests.Integration.WaveManagerTests
{
    [IntegrationTest.DynamicTest("WaveManagerTests")]
    class it_spawns_wave_actors : test_case
    {
        public override void SetUp ()
        {
            base.SetUp();

            factory.Expects("CreateEnemyShip").ToBeCalled(1).AndReturns(enemy);
            
            wave_manager.enemiesInWave = 1;
        }

        void Test ()
        {
            AssertThat(factory.MeetsExpectations());
        }
    }
}