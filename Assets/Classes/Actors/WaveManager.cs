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
                
        private IPhysicalFactory factory;
        private IRegistryService registry;
        private IPlanet planet;

        /// <summary>
        /// resolve references to services.
        /// </summary>
        void Awake ()
        {
            factory = IOC.Resolve<IPhysicalFactory>();
            registry = IOC.Resolve<IRegistryService>();
        }

        /// <summary>
        /// resolve references to other actors
        /// </summary>
        void Start ()
        {
            planet = registry.LookUp<IPlanet>("Planet");

            for (int i = 0; i < enemiesInWave; ++i) {
                IPhysical enemy = factory.CreateEnemyShip();

                Location spawnPoint = planet.GetRandomSpawnPoint();

                enemy.MoveToLocation(spawnPoint);
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
