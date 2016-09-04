using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;
using System.Collections.Generic;

using SpaceGame.Exceptions;

namespace SpaceGame.Actors
{
    public class WaveManager : MonoBehaviour
    {
        [Tooltip("the number of enemies that will be in the current wave")]
        public int enemiesInWave = 0;

        [Tooltip("the number of coins that will be in the current wave")]
        public int coinsInWave = 0;

        [Tooltip("data about the waves in the game")]
        public WaveData waveData;

        private WaveData.Wave currentWave;

        // creates enemies
        private IEnemyFactory enemies;

        // creates coins
        private ICollectableFactory collectables;

        // control the round timer
        private ITimeService time;

        // find other objects
        private IRegistryService registry;

        // get information about where to spawn things
        private IPlanet planet;

        // list of enemies that currently exist in the game
        private List<Saucer> enemyList;

        /// <summary>
        /// resolve references to services.
        /// </summary>
        void Awake()
        {
            enemies = IOC.Resolve<IEnemyFactory>();

            collectables = IOC.Resolve<ICollectableFactory>();

            time = IOC.Resolve<ITimeService>();

            registry = IOC.Resolve<IRegistryService>();

            enemyList = new List<Saucer>();
        }

        /// <summary>
        /// resolve references to other actors. 
        /// TODO: Move this logic to a 'wave start' that is executed after showing wave info.
        /// </summary>
        void Start()
        {
            planet = registry.LookUp<IPlanet>("Planet");

            if (waveData == null) {
                throw new ReferenceNotFoundException("Wave manager cannot find wave data.");
            }

            if (waveData.waves.Length < 1) {
                throw new InvalidDataException("Wave data should have at least 1 wave.");
            }

            currentWave = waveData.waves[0];

            for (int i = 0; i < currentWave.saucers; ++i) {
                IEnemy enemy = enemies.CreateSaucer();
                Location spawnPoint = planet.GetRandomSpawnPoint();
                enemy.MoveToLocation(spawnPoint);

                enemyList.Add((Saucer)enemy);
            }

            for (int i = 0; i < coinsInWave; i++) {
                ICollectable collectable = collectables.CreateCoin();
                Location spawnPoint = planet.GetRandomSpawnPoint();
                collectable.MoveToLocation(spawnPoint);
            }

            time.SetCountdown(10);
            time.StartCountdown();
        }
    }
}
