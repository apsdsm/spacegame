using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;
using System;

namespace SpaceGame.Actors
{
    public class WaveManager : MonoBehaviour
    {
        [Tooltip("the number of enemies that will be in the current wave")]
        public int enemiesInWave = 0;

        [Tooltip("the number of coins that will be in the current wave")]
        public int coinsInWave = 0;
                
		private IPhysicalFactory physicalFactory;
		private ICollectableFactory collectableFactory;
        private IRegistryService registry;
        private IPlanet planet;

        /// <summary>
        /// resolve references to services.
        /// </summary>
        void Awake ()
        {
            physicalFactory = IOC.Resolve<IPhysicalFactory>();
			collectableFactory = IOC.Resolve<ICollectableFactory>();
            registry = IOC.Resolve<IRegistryService>();
        }

        /// <summary>
        /// resolve references to other actors
        /// </summary>
        void Start ()
        {
            planet = registry.LookUp<IPlanet>("Planet");

            for (int i = 0; i < enemiesInWave; ++i) {
                IPhysical enemy = physicalFactory.CreateEnemyShip();
                Location spawnPoint = planet.GetRandomSpawnPoint();
                enemy.MoveToLocation(spawnPoint);
            }

			for (int i = 0; i < coinsInWave; i++) {
			    ICollectable collectable = collectableFactory.CreateCoin();
                Location spawnPoint = planet.GetRandomSpawnPoint();
                collectable.MoveToLocation(spawnPoint);
			}
        }

        /// <summary>
        /// Creates a new enemy if enough time has passed, and if the maximum 
        /// number of enemies for the wave has not yet been reached.
        /// </summary>
        void Update ()
        {

        }
    }
}
