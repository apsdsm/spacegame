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

            // set expectations

            registry.Expects<IPlanet>("LookUp").With("Planet").AndReturns<IPlanet>(planet);
           
            planet.Expects("GetRandomSpawnPoint").ToBeCalled(2).AndReturns<Location>(new Location());

            physical_factory.Expects("CreateEnemyShip").ToBeCalled(1).AndReturns<IPhysical>(enemy);

            enemy.Expects("MoveToLovation").ToBeCalled(1);

            collectable_factory.Expects("CreateCoin").ToBeCalled(1).AndReturns<ICollectable>(collectable);

            collectable.Expects("MoveToLocation").ToBeCalled(1);
           
            planet.Expects("GetRandomSpawnPoint").ToBeCalled(2).AndReturns<Vector3>(Vector3.one);

            // set up wave manager

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
