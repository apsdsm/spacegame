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
        private SphereCollider sphereCollider;

        public float spawnHeight = 4.0f;

        // allows other objects to access the planet with direct relation
        private IRegistryService registry;

        /// <summary>
        /// Set up planet.
        /// </summary>
        void Awake ()
        {
            // get components
            sphereCollider = GetComponent<SphereCollider>();

            // resolve services
            registry = IOC.Resolve<IRegistryService>();

            // register object
            registry.Register<IPlanet>("Planet", this);
        }

     
        /// <summary>
        /// Enact gravity on any object subscribed to the gravity registry.
        /// </summary>
        void Update ()
        {
        }
            
        public Location GetRandomSpawnPoint ()
        {
            Location spawnPoint = new Location();

            spawnPoint.orientation = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
            spawnPoint.position = spawnPoint.orientation * (sphereCollider.radius + spawnHeight);

            return spawnPoint;
        }

        public Vector3 core
        {
            get { return transform.position; }
        }

        public SphereCollider surface 
        {
            get { return sphereCollider; }
        }
            
    }
}
