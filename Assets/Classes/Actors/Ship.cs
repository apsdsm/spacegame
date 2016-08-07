using UnityEngine;
using SpaceGame.Interfaces;
using SpaceGame.Behaviours;
using Fletch;

namespace SpaceGame.Actors
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PhysicalBehaviour))]
    public class Ship : MonoBehaviour, IControllableShip
    {
        // controls the ships movement
        private Rigidbody rigid;

        // controls the ships movements
        private IShipController controller;

        // creates the bullets shot by the ship
        private IShootableFactory bullets;

        // allows other objects to access the planet with direct relation
        private IRegistryService registry;

        // private planet reference
        private IPlanet planet;
        
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
            bullets = IOC.Resolve<IShootableFactory>();
            registry = IOC.Resolve<IRegistryService>();

            // subscribe to services
            controller.Register(this);
        }

        /// <summary>
        /// Load reference to objects that were set up during Awake.
        /// </summary>
        void Start ()
        {
            planet = registry.LookUp<IPlanet>("Planet");
        }


        /// <summary>
        /// Deregister the ship from any services it is subscribed to.
        /// </summary>
        public void OnDestroy ()
        {
            controller.Deregister(this);
        }


        /// <summary>
        /// Add forward/backwards thrust to ship.
        /// </summary>
        /// <param name="thrust">amount of thrust to add</param>
        public void AddLongitudinalThrust (float thrust)
        {
            rigid.AddRelativeForce(Vector3.forward * thrust);
        }


        /// <summary>
        /// Add left/right rotational thrust to ship.
        /// </summary>
        /// <param name="thrust">amount of thrust to add</param>
        public void AddRotationalThrust (float thrust)
        {
            rigid.AddRelativeTorque(Vector3.up * thrust);
        }


        /// <summary>
        /// Fire a projectile from the ship, in the direction the ship is facing.
        /// </summary>
        public void Shoot ()
        {
            bullets.CreatePlayerBullet().Shoot(transform.position, transform.forward, planet.CoreLocation);
        }
    }
}
