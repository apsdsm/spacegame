using UnityEngine;
using SpaceGame.Interfaces;
using SpaceGame.Behaviours;
using Fletch;

namespace SpaceGame.Actors
{
    [RequireComponent(typeof(PhysicalBehaviour))]
    public class Ship : MonoBehaviour, IControllableShip
    {


        public float cruiseAcceleration = 20.0f;

        [Tooltip("how quickly the ship starts moving")]
        public float acceleration = 5.0f;

        [Tooltip("how quickly the ship can turn")]
        public float rotation = 5.0f;

        // controls the ships movements
        private IShipController controller;

        // creates the bullets shot by the ship
        private IShootableFactory bullets;

        // allows other objects to access the planet with direct relation
        private IRegistryService registry;

        // private planet reference
        private IPlanet planet;

        private PhysicalBehaviour physical;

        /// <summary>
        /// Set up components and subscribe to services.
        /// </summary>
        void Awake ()
        {

            // get services
            controller = IOC.Resolve<IShipController>();
            bullets = IOC.Resolve<IShootableFactory>();
            registry = IOC.Resolve<IRegistryService>();

            // get components
            physical = GetComponent<PhysicalBehaviour>();

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

        void Update ()
        {
            Debug.DrawRay(transform.position, transform.up * 2.0f, Color.red);
            Debug.DrawRay(transform.position, transform.forward * 2.0f, Color.blue);

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
            physical.AddForce(transform.forward * thrust * acceleration);
        }


        /// <summary>
        /// Add left/right rotational thrust to ship.
        /// </summary>
        /// <param name="thrust">amount of thrust to add</param>
        public void AddRotationalThrust (float thrust)
        {
            transform.RotateAround(transform.position, transform.up, thrust * rotation);
        }


        /// <summary>
        /// Fire a projectile from the ship, in the direction the ship is facing.
        /// </summary>
        public void Shoot ()
        {
            bullets.CreatePlayerBullet().Shoot(transform.position, transform.forward, planet.core);
        }
            
    }
}
