using UnityEngine;
using SpaceGame.Interfaces;
using SpaceGame.Exceptions;
using Fletch;

namespace SpaceGame.Actors
{
    [RequireComponent( typeof( Rigidbody ) )]
    public class Ship : MonoBehaviour, IControllable, IPhysical
    {
        // controls the ships movement
        private Rigidbody rigid;

        // controls the ships movements
        private IShipController controller;

        // lets planets know to apply gravity to ship
        private IGravityService gravity;

        // creates the bullets shot by the ship
        private IShootableFactory bullets;


        /// <summary>
        /// Set up components and subscribe to services.
        /// </summary>
        void Awake ()
        {
            // get components
            rigid = GetComponent<Rigidbody>();

            // setup components
            rigid.useGravity = false;

            // get services
            controller = IOC.Resolve<IShipController>();
            gravity = IOC.Resolve<IGravityService>();
            bullets = IOC.Resolve<IShootableFactory>();

            // subscribe to services
            gravity.Register( this );
            controller.Register( this );
        }


        /// <summary>
        /// Deregister the ship from any services it is subscribed to.
        /// </summary>
        public void OnDestroy ()
        {
            controller.Deregister( this );
            gravity.Deregister( this );
        }


        /// <summary>
        /// Add forward/backwards thrust to ship.
        /// </summary>
        /// <param name="thrust">amount of thrust to add</param>
        public void AddLongitudinalThrust ( float thrust )
        {
            rigid.AddRelativeForce( Vector3.forward * thrust );
        }


        /// <summary>
        /// Add left/right rotational thrust to ship.
        /// </summary>
        /// <param name="thrust">amount of thrust to add</param>
        public void AddRotationalThrust ( float thrust )
        {
            rigid.AddRelativeTorque( Vector3.up * thrust );
        }


        /// <summary>
        /// Fire a projectile from the ship, in the direction the ship is facing.
        /// </summary>
        public void Shoot ()
        {
            bullets.CreatePlayerBullet().Shoot( transform.position, transform.forward );
        }


        /// <summary>
        /// Add external force to the object.
        /// </summary>
        /// <param name="force">Vector3 representing force to add</param>
        public void AddForce ( Vector3 force )
        {
            rigid.AddForce( force );
        }


        /// <summary>
        /// Return the ship's current position.
        /// </summary>
        /// <returns>Vector3 of ship's current postion</returns>
        public Vector3 GetPosition ()
        {
            return transform.position;
        }


        /// <summary>
        /// Set the ship's current position.
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition ( Vector3 position )
        {
            transform.position = position;
        }
    }
}
