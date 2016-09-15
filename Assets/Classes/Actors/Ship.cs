using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;
using System;

namespace SpaceGame.Actors {

    [RequireComponent(typeof(Rigidbody))]
    public class Ship : MonoBehaviour, IShip {

        [Tooltip("basic speed of ship")]
        public float cruiseSpeed = 20.0f;

        [Tooltip("how quickly the ship starts moving")]
        public float acceleration = 5.0f;

        [Tooltip("how quickly the ship can turn")]
        public float rotation = 5.0f;

        [Tooltip("how far off the surface of the planet the ship should be")]
        public float distanceFromSurface = 1.0f;

        private IShipController controller;

        private IShootableFactory bullets;

        private IRegistryService registry;

        private IPlanet planet;

        private Rigidbody rigid;

        private Vector3 calculatedVelocity;

        private Location currentLocation;



        // Monobehaviour
        //

        void Awake() {

            // get services
            controller = IOC.Resolve<IShipController>();
            bullets = IOC.Resolve<IShootableFactory>();
            registry = IOC.Resolve<IRegistryService>();

            // get and initialize components
            rigid = GetComponent<Rigidbody>();
            rigid.constraints = RigidbodyConstraints.FreezeRotation;
            rigid.useGravity = false;

            // register with services and controllers
            controller.Register(this);
            registry.Register<IShip>("Ship", this);

        }

        void Start() {
            planet = registry.LookUp<IPlanet>("Planet");
        }

        void Update() {

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

            // update location orientation
            currentLocation.orientation = transform.up;
        }

        void FixedUpdate() {

            // get a new forward position
            Vector3 newPosition = transform.position + (transform.forward * cruiseSpeed * Time.deltaTime);

            // adjust height to be over planet
            Vector3 heightNormalised = (newPosition - planet.core).normalized * (planet.surface.radius);

            // get new velocity
            calculatedVelocity = (heightNormalised - transform.position).normalized * cruiseSpeed;

            // move to new position
            rigid.MovePosition(heightNormalised);

            // update location position
            currentLocation.position = transform.position;
        }

        public void OnDestroy() {
            registry.Deregister<Ship>("Ship");
            controller.Deregister(this);
        }



        // IShip
        //

        public Location location { get { return currentLocation; } }

        public void AddLongitudinalThrust(float thrust) {
            rigid.AddForce(transform.forward * thrust * acceleration);
        }
                
        public void AddRotationalThrust(float thrust) {
            transform.RotateAround(transform.position, transform.up, (thrust * rotation) * Time.deltaTime);
        }

        public void Shoot() {
            bullets.CreatePlayerBullet().Shoot(transform.position, transform.forward, planet.core);
        }

    }
}
