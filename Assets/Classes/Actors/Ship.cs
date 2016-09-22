using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;
using System;
using SpaceGame.Events;

namespace SpaceGame.Actors {

    [RequireComponent(typeof(Rigidbody))]
    public class Ship : MonoBehaviour, IShip {

        [Tooltip("basic speed of ship")]
        public float cruiseSpeed = 20.0f;

        [Tooltip("top speed of ship while boosting")]
        public float boostSpeed = 40.0f;

        [Tooltip("how quickly the ship can turn")]
        public float cruiseRotation = 80.0f;

        [Tooltip("how quickly the ship can turn while boosting")]
        public float boostRotation = 50.0f;

        [Tooltip("how quickly the ship gets from crusing speed to top speed")]
        public float acceleration = 5.0f;

        [Tooltip("how quicly the ship gets from boosted speed back to normal speed")]
        public float deceleration = 10.0f;

        [Tooltip("how far off the surface of the planet the ship should be")]
        public float distanceFromSurface = 1.0f;

        private IShipController controller; // sends player input to the ship

        private IShootableFactory bullets; // factory for ship projectiles

        private IRegistryService registry; // object registry

        private IPlanet planet; // the planet the ship is bound to

        private Rigidbody rigid; // rigid body component

        private bool isBoosting; // true if ship is currently boosting

        private float currentSpeed; // the current speed of the ship.

        private float currentRotationSpeed; // the current rotational speed of the ship.

        // allocate memory for heavily used variables //

        // fixed update
        private Location currentLocation;
        private Vector3 heightNormalisedPosition;
        private Vector3 newPosition;

        // update
        private Vector3 correctUp;
        private Vector3 currentUp;
        private Quaternion correctRotation;




        //////////////////////////////////////////////////////////////////////////////////
        // MonoBehaviour
        //

        /// <summary>
        /// get references to services and internal components.
        /// </summary>
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

        /// <summary>
        /// Look up other actors.
        /// </summary>
        void Start() {
            planet = registry.LookUp<IPlanet>("Planet");
        }

        /// <summary>
        /// Adjust the ship's rotation so that it's Y axis points directly away from planet core.
        /// </summary>
        void Update() {

            // get the current up angle and the correct up angle
            correctUp = (transform.position - planet.core).normalized;
            currentUp = transform.up;

            // get quaternion representing the correct rotation
            correctRotation = Quaternion.FromToRotation(currentUp, correctUp) * transform.rotation;

            // slerp towards the correct rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, correctRotation, 10 * Time.deltaTime);

            // update location orientation
            currentLocation.orientation = transform.up;

            CorrectSpeed();

            CorrectRotationSpeed();

            // reset isBoosting
            isBoosting = false;

        }

        private void CorrectRotationSpeed() {

            // if ship is not boosting and speed is the cruising speed, then return.
            if (!isBoosting && currentRotationSpeed == cruiseRotation) {
                return;
            }

            // if the ship is boosting but the speed is already at top speed, set boost to false and return
            if (isBoosting && currentRotationSpeed == boostRotation) {
                return;
            }

            // if boosting but not yet at top speed
            if (isBoosting && currentRotationSpeed < boostRotation) {
                currentRotationSpeed -= acceleration * Time.deltaTime;
            }

            // if not boosting but speed faster than cruisting speed
            if (!isBoosting && currentRotationSpeed > cruiseRotation) {
                currentRotationSpeed += deceleration * Time.deltaTime;
            }

            // make sure speed is inside range
            currentRotationSpeed = Mathf.Clamp(currentRotationSpeed, cruiseRotation, boostRotation);
            
        }

        private void CorrectSpeed() {

            // if ship is not boosting and speed is the cruising speed, then return.
            if (!isBoosting && currentSpeed == cruiseSpeed) {
                return;
            }

            // if the ship is boosting but the speed is already at top speed, set boost to false and return
            if (isBoosting && currentSpeed == boostSpeed) {
                return;
            }

            // if boosting but not yet at top speed
            if (isBoosting && currentSpeed < boostSpeed) { 
                currentSpeed += acceleration * Time.deltaTime;              
            }

            // if not boosting but speed faster than cruisting speed
            if (!isBoosting && currentSpeed > cruiseSpeed) {
                currentSpeed -= deceleration * Time.deltaTime;
            }

            // make sure speed is inside range
            currentSpeed = Mathf.Clamp(currentSpeed, cruiseSpeed, boostSpeed);

            CallOnSpeedChange(currentSpeed);
        }

        /// <summary>
        /// Change the ship's position on the planet.
        /// </summary>
        void FixedUpdate() {

            // get a new forward position
            newPosition = transform.position + (transform.forward * currentSpeed * Time.deltaTime);

            // adjust height to be over planet
            heightNormalisedPosition = (newPosition - planet.core).normalized * (planet.surface.radius);

            // move to new position
            rigid.MovePosition(heightNormalisedPosition);

            // update location position
            currentLocation.position = transform.position;
        }

        /// <summary>
        /// Deregister ship from services and controllers.
        /// </summary>
        public void OnDestroy() {
            registry.Deregister<Ship>("Ship");
            controller.Deregister(this);
        }




        //////////////////////////////////////////////////////////////////////////////////
        // Events
        //

        /// <summary>
        /// Called when the ship changes speed. See IShip.
        /// </summary>
        public event SpeedChangedEvent onSpeedChanged;




        //////////////////////////////////////////////////////////////////////////////////
        // Getters / Setters
        //

        /// <summary>
        /// Current location of ship. See IShip
        /// </summary>
        public Location location { get { return currentLocation; } }




        //////////////////////////////////////////////////////////////////////////////////
        // Public Methods
        //

        /// <summary>
        /// Rotate the ship on an axis running from the ships position to the planet core. See IShip.
        /// </summary>
        /// <param name="thrust"></param>
        public void Turn(float thrust) {
            transform.RotateAround(transform.position, transform.up, (thrust * currentRotationSpeed) * Time.deltaTime);
        }

        /// <summary>
        /// Make the ship fly faster, but reduce turning speed.
        /// </summary>
        public void BoostSpeed() {
            isBoosting = true;
        }

        /// <summary>
        /// Shoot projectile from ship. See IShip.
        /// </summary>
        public void Shoot() {
            bullets.CreatePlayerBullet().Shoot(transform.position, transform.forward, planet.core);
        }




        //////////////////////////////////////////////////////////////////////////////////
        // Private Methods
        //

        /// <summary>
        /// Call the onSpeedChanged event if there are any subscribers.
        /// </summary>
        /// <param name="speed">new speed</param>
        private void CallOnSpeedChange(float speed) {
            if (onSpeedChanged != null) {
                onSpeedChanged(speed);
            }
        }
    }
}
