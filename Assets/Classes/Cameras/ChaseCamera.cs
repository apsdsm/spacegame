using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;

namespace SpaceGame.Cameras
{
    /// <summary>
    /// Rewrite this class.
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public class ChaseCamera : MonoBehaviour
    {
        [Tooltip("distance the camera will be from the target.")]
        public float distance = 10.0f;

        [Tooltip("angle of the camera behind target.")]
        public float angle = 45.0f;

        [Tooltip("how stiff the camera movement will be.")]
        public float damping = 5.0f;

        // services
        private IRegistryService registry;

        // actors
        private IShip ship;

        // keep these in variables so that we don't constantly allocate memory for them
        private Vector3 idealPosition;
        private Vector3 projectionVector;
        private Quaternion cameraRotation;

        /// <summary>
        /// Get reference to the registry.
        /// </summary>
        void Awake() {
            registry = IOC.Resolve<IRegistryService>();
        }

        /// <summary>
        /// Get a reference to the ship, then put the camera in the ideal starting position.
        /// </summary>
        void Start() {
            ship = registry.LookUp<IShip>("Ship");

            // start the camera out in the ideal position
            UpdateIdealPosition();
            transform.position = idealPosition;
            transform.LookAt(ship.transform.position, ship.transform.up);
        }

        /// <summary>
        /// interpolate the camera's position towards where it should be, ideally.
        /// </summary>
        void FixedUpdate() {
            UpdateIdealPosition();

            transform.position = Vector3.Lerp(transform.position, idealPosition, Time.deltaTime * damping);

            transform.LookAt(ship.transform.position, ship.transform.up);
        }

        /// <summary>
        /// Calculate where the camera would be, ideally, if the ship weren't moving.
        /// </summary>
        private void UpdateIdealPosition() {
            cameraRotation = Quaternion.AngleAxis(angle, ship.transform.right);           
            projectionVector = cameraRotation * ship.transform.forward;
            idealPosition = ship.location.position + (projectionVector * -distance);
        }
    }
}
