using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;

namespace SpaceGame.Actors
{
    /// <summary>
    /// The player is in control of the ship that hovers around the surface of the planet.
    /// </summary>
    public class Player : IUpdatable, IPhysical
    {
        // agent
        IAgent agent;

        // factories
        IBulletFactory bullets;

        // services
        IInputService input;
        IGravityService gravity;
        IRegistryService registry;

        // controllers
        IPhysicsController ship;

        /// <summary>
        /// Set up a new player object.
        /// </summary>
        /// <param name="agent">agent responsible for the player</param>
        /// <param name="ship">ship controller</param>
        /// <param name="input">input service</param>
        /// <param name="gravity">gravity service</param>
        /// <param name="registry">registry service</param>
        public Player ( IAgent agent, 
                        IPhysicsController ship,
                        IBulletFactory bullets = null,
                        IInputService input = null,
                        IGravityService gravity = null,
                        IRegistryService registry = null )
        {
            // agent
            this.agent = agent;

            // controllers
            this.ship = ship;

            // factories
            this.bullets = bullets ?? IOC.Resolve<IBulletFactory>();

            // services
            this.input = input ?? IOC.Resolve<IInputService>();
            this.gravity = gravity ?? IOC.Resolve<IGravityService>();
            this.registry = registry ?? IOC.Resolve<IRegistryService>();

            // add self to registry
            this.registry.Register<IPhysical>( "Player", this );
            this.gravity.Register( this );
        }

        /// <summary>
        /// Update the player object.
        /// </summary>
        public void Update ( float deltaTime = 0.0f )
        {
            Vector2 movement = input.GetMovement();

            ship.AddRelativeForce( new Vector3( 0.0f, 0.0f, movement.y ) );
            ship.AddRelativeTorque( new Vector3( 0.0f, movement.x, 0.0f ) );

            if ( input.GetWeaponFired() )
            {
                IShootable bullet = bullets.CreatePlayerBullet();
                bullet.Shoot( agent.Position + agent.Forward * 1.0f, agent.Forward );
            }
        }

        /// <summary>
        /// Return the player's current position.
        /// </summary>
        /// <returns></returns>
        public Vector3 GetPosition()
        {
            return agent.Position;
        }

        /// <summary>
        /// Set the player's current position.
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition ( Vector3 position )
        {
            agent.Position = position;
        }

        /// <summary>
        /// Add force to the player.
        /// </summary>
        /// <param name="force">vector representing force to add to player.</param>
        public void AddForce ( Vector3 force )
        {
            ship.AddForce( force );
        }
    }
}
