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
        private IEnemyFactory enemyFactory;

        // creates coins
        private ICollectableFactory collectableFactory;

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
            enemyFactory = IOC.Resolve<IEnemyFactory>();
            collectableFactory = IOC.Resolve<ICollectableFactory>();
            registry = IOC.Resolve<IRegistryService>();

            enemyList = new List<Saucer>();

            if (waveData == null) {
                throw new ReferenceNotFoundException("Wave manager cannot find wave data.");
            }

            if (waveData.waves.Length < 1) {
                throw new InvalidDataException("Wave data should have at least 1 wave.");
            }

            currentWave = waveData.waves[0];
        }

        /// <summary>
        /// resolve references to other actors
        /// </summary>
        void Start()
        {
            planet = registry.LookUp<IPlanet>("Planet");

            for (int i = 0; i < currentWave.saucers; ++i)
            {
                IEnemy enemy = enemyFactory.CreateSaucer();
                Location spawnPoint = planet.GetRandomSpawnPoint();
                enemy.MoveToLocation(spawnPoint);

                enemyList.Add((Saucer)enemy);
            }

            for (int i = 0; i < coinsInWave; i++)
            {
                ICollectable collectable = collectableFactory.CreateCoin();
                Location spawnPoint = planet.GetRandomSpawnPoint();
                collectable.MoveToLocation(spawnPoint);
            }
        }
    }
}
