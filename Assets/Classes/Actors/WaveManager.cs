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

        // number of enemies that have been created in this wave
        private int enemiesCreated = 0;

        [Tooltip("the amount of time that passes before a new enemy is spawned")]
        public float spawnCooldown = 1.0f;

        // time that has passed since last enemy was spawned
        private float timeSinceSpawn = 0.0f;

        [Tooltip("the height above the surface at which new enemies will spawn")]
        public float spawnHeight = 3.0f;

        // creates new enemies
        private IPhysicalFactory factory;

        // provides references to other actors
        private IRegistryService registry;

        // provides locations to spawn enemies
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
        }

        /// <summary>
        /// Creates a new enemy if enough time has passed, and if the maximum 
        /// number of enemies for the wave has not yet been reached.
        /// </summary>
        void Update ()
        {
            if (enemiesCreated >= enemiesInWave)
            {
                return;
            }

            if (timeSinceSpawn >= spawnCooldown)
            {
                IPhysical enemy = factory.CreateEnemyShip();

                Vector3 spawnPosition = planet.GetRandomPosition(spawnHeight);

                enemy.SetPosition(spawnPosition);
                
                timeSinceSpawn = 0;

                enemiesCreated++;
            }

            timeSinceSpawn += Time.deltaTime;
        }
    }
}
