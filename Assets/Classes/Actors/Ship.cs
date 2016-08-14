using UnityEngine;
using SpaceGame.Interfaces;
using SpaceGame.Behaviours;
using Fletch;

namespace SpaceGame.Actors
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ship : MonoBehaviour, IControllableShip
    {

        [Tooltip("basic speed of ship")]
        public float cruiseSpeed = 20.0f;

        [Tooltip("how quickly the ship starts moving")]
        public float acceleration = 5.0f;

        [Tooltip("how quickly the ship can turn")]
        public float rotation = 5.0f;

        private IShipController controller;

        private IShootableFactory bullets;
       
        private IRegistryService registry;

        private IPlanet planet;

        private Rigidbody rigid;

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
            rigid = GetComponent<Rigidbody>();
            rigid.constraints = RigidbodyConstraints.FreezeRotation;
            rigid.useGravity = false;

            // register with services and controllers
            controller.Register(this);
            registry.Register<Ship>("Ship", this);
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
            // debug rays - groovy
            Debug.DrawRay(transform.position, transform.up * 2.0f, Color.red);
            Debug.DrawRay(transform.position, transform.forward * 2.0f, Color.blue);

            // get the current up angle and the correct up angle
            Vector3 correctUp = (transform.position - planet.core).normalized;
            Vector3 currentUp = transform.up;

            // get quaternion representing the correct rotation
            Quaternion correctRotation = Quaternion.FromToRotation(currentUp, correctUp) * transform.rotation;

            // slerp towards the correct rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, correctRotation, 10 * Time.deltaTime);  
        }

        void FixedUpdate ()
        {
            // add gracity to object
            Vector3 gravity = (planet.core - transform.position).normalized * (10.0f + planet.GetDistanceFromSurface(transform.position));
            rigid.AddForce(gravity);

            // make sure speed isn't above cruise speed
            if (rigid.velocity.magnitude > cruiseSpeed) {
                rigid.velocity = rigid.velocity.normalized * cruiseSpeed;
            }
        }


        /// <summary>
        /// Deregister the ship from any services it is subscribed to.
        /// </summary>
        public void OnDestroy ()
        {
            registry.Deregister<Ship>("Ship");
            controller.Deregister(this);
        }


        /// <summary>
        /// Add forward/backwards thrust to ship.
        /// </summary>
        /// <param name="thrust">amount of thrust to add</param>
        public void AddLongitudinalThrust (float thrust)
        {
            rigid.AddForce(transform.forward * thrust * acceleration);
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
