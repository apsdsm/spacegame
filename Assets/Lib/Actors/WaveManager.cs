using UnityEngine;
using System.Collections.Generic;
using SpaceGame.Interfaces;
using SpaceGame.Agents;
using Fletch;

namespace SpaceGame.Actors
{
    public class WaveManager : IUpdatable, IWaveManager
    {
        // used to build new enemy ships
        IShipFactory factory;

        // planet applies gravity to anything registered to this service
        IGravityService gravity;

        // used to get reference to Planet actor
        IRegistryService registry;

        // list of enemies being managed
        private List<IPhysical> ships;

        // maximum number of enemies that can exist at one time
        private int maxEnemies;

        // how long between spawning new enemies
        private float spawnCooldown;

        // time elapsed since last enemy was spawned
        private float timeSinceSpawn = 0.0f;

        // planet reference used to calculate where to spawn enemies
        private IPlanet planet;

        // how high above planet to spawn new enemies
        private float spawnHeight = 10.0f;

        /// <summary>
        /// Set the max number of enemies.
        /// </summary>
        public int MaxEnemies
        { set { maxEnemies = value; } }

        /// <summary>
        /// Set the spawn cool down.
        /// </summary>
        public float SpawnCooldown
        { set { spawnCooldown = value; } }

        /// <summary>
        /// Set the planet used by the manager.
        /// </summary>
        public IPlanet Planet
        { set { this.planet = value; } }

        /// <summary>
        /// Set the spawn height used by the manager.
        /// </summary>
        public float SpawnHeight
        { set { this.spawnHeight = value; } }

        /// <summary>
        /// Get array of all ship in wave.
        /// </summary>
        public IPhysical[] Ships
        { get { return ships.ToArray(); } }
        

        /// <summary>
        /// Constructor for Wave Manager
        /// </summary>
        public WaveManager ( IAgent agent, 
                             IShipFactory factory = null, 
                             IGravityService gravity = null, 
                             IRegistryService registry = null )
        {
            // dependencies
            this.factory = factory ?? IOC.Resolve<IShipFactory>();
            this.gravity = gravity ?? IOC.Resolve<IGravityService>();
            this.registry = registry ?? IOC.Resolve<IRegistryService>();

            // make reservations
            this.registry.Reserve<IPlanet>( "Planet", this );

            // set internal variables
            spawnCooldown = 1.0f;
            maxEnemies = 1;
            ships = new List<IPhysical>();
        }


        /// <summary>
        /// Spawn enemies if required
        /// </summary>
        /// <param name="deltaTime">time passed since last update</param>
        public void Update ( float deltaTime = 0.0f )
        {
            // check dependencies
            if ( factory == null || planet == null )
            {
                return;
            }

            timeSinceSpawn += deltaTime;

            while ( timeSinceSpawn >= spawnCooldown && deltaTime != 0.0f )
            {
                if ( ships.Count < maxEnemies )
                {
                    Vector3 startPos = planet.GetRandomPosition( spawnHeight );

                    IPhysical ship = factory.CreateEnemyShip();
                    
                    ship.SetPosition( startPos );

                    if ( ship is IPhysical )
                    {
                        gravity.Register( ( IPhysical ) ship );
                    }

                    ships.Add( ship );
                }

                timeSinceSpawn -= spawnCooldown;
            }
        }
    }
}
