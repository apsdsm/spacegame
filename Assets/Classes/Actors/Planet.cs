using UnityEngine;
using Random = UnityEngine.Random;
using SpaceGame.Interfaces;
using Fletch;
using System;

namespace SpaceGame.Actors
{
    [RequireComponent(typeof(SphereCollider))]
    public class Planet : MonoBehaviour, IPlanet
    {
        // describes the size and surface of the planet
        private SphereCollider surface;

        // keeps a list of which objects want gravity
        private IGravityService gravity;

        // allows other objects to access the planet with direct relation
        private IRegistryService registry;


        /// <summary>
        /// Set up planet.
        /// </summary>
        void Awake ()
        {
            // get components
            surface = GetComponent<SphereCollider>();

            // resolve services
            gravity = IOC.Resolve<IGravityService>();
            registry = IOC.Resolve<IRegistryService>();

            // register object
            registry.Register<IPlanet>("Planet", this);
        }


        /// <summary>
        /// Enact gravity on any object subscribed to the gravity registry.
        /// </summary>
        void Update ()
        {
            IPhysical[] targets = gravity.Targets();
            
            foreach (IPhysical target in targets)
            {
                Vector3 targetPosition = target.Position;
                Vector3 gravityToTarget = transform.position - targetPosition;

                target.AddForce(gravityToTarget);
            }
        }

        public SpawnPoint GetRandomSpawnPoint ()
        {
            SpawnPoint spawnPoint = new SpawnPoint();

            spawnPoint.orientation = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
            spawnPoint.position = spawnPoint.orientation * surface.radius;

            return spawnPoint;
        }

        public Vector3 CoreLocation
        {
            get { return transform.position; }
        }
    }
}
