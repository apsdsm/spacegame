using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;

namespace SpaceGame.Actors
{
    public class Planet : IUpdatable, IPlanet
    {
        // agent
        private IAgent agent;

        // controllers
        private ITransformController transform;

        // services
        private IGravityService gravity;
        private IRegistryService registry;

        // reporters
        private IPlanetSizeReporter size;

        /// <summary>
        /// Create a new planet object.
        /// </summary>
        /// <param name="agent"></param>
        /// <param name="registry"></param>
        public Planet ( IAgent agent,
                        ITransformController transform, 
                        IPlanetSizeReporter size,
                        IGravityService gravity = null,
                        IRegistryService registry = null )
        {
            // agent
            this.agent = agent;

            // controllers
            this.transform = transform;

            // reporters
            this.size = size;

            // services
            this.gravity = gravity ?? IOC.Resolve<IGravityService>();
            this.registry = registry ?? IOC.Resolve<IRegistryService>();

            // register self
            this.registry.Register<IPlanet>( "Planet", this );
        }


        /// <summary>
        /// Add gravity force to all the things.
        /// </summary>
        public void Update ( float deltaTime = 0.0f )
        {
            if ( gravity == null )
            {
                return;
            }

            Vector3 position = transform.Position;

            foreach ( IPhysical target in gravity.GetTargets() )
            {

                Vector3 targetPosition = target.GetPosition();

                Vector3 gravityToTarget = position - targetPosition;

                target.AddForce( gravityToTarget );
            }
        }


        /// <summary>
        /// Generates a random position a given distance from the surface
        /// </summary>
        /// <param name="distanceFromSurface"></param>
        public Vector3 GetRandomPosition ( float distanceFromSurface )
        {
            Vector3 orientation = new Vector3( Random.Range( -1.0f, 1.0f ), Random.Range( -1.0f, 1.0f ), Random.Range( -1.0f, 1.0f ) ).normalized;
            Vector3 projection = orientation * ( size.GetSize() + distanceFromSurface );

            return projection;
        }
    }
}
