using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;

namespace SpaceGame.Actors
{
    [RequireComponent(typeof(SphereCollider))]
    class Planet : MonoBehaviour, IPlanet
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
            IPhysical[] targets = gravity.GetTargets();
            
            foreach (IPhysical target in targets)
            {
                Vector3 targetPosition = target.Position;
                Vector3 gravityToTarget = transform.position - targetPosition;

                target.AddForce(gravityToTarget);
            }
        }


        /// <summary>
        /// Provides a random point above the surface of the planet
        /// </summary>
        /// <param name="distanceFromSurface">How high above the surface the position should be</param>
        /// <returns>Vector3 describing new position</returns>
        public Vector3 GetRandomPosition (float distanceFromSurface)
        {
            Vector3 orientation = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
            Vector3 projection = orientation * (surface.radius + distanceFromSurface);

            return projection;
        }
    }
}
