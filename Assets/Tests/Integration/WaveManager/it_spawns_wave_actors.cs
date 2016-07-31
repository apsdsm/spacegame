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

            collectable_factory.Expects("CreateCoin").ToBeCalled(1).AndReturns(collectable);

            physical_factory.Expects("CreateEnemyShip").ToBeCalled(1).AndReturns(enemy);
            
            wave_manager.enemiesInWave = 1;

            wave_manager.coinsInWave = 1;
        }

        void Test ()
        {
            AssertThat(physical_factory.MeetsExpectations());
            AssertThat(collectable_factory.MeetsExpectations());
        }
    }
}