using UnityEngine;
using SpaceGame.Interfaces;

namespace SpaceGame.Controllers {

    /// <summary>
    /// Takes an IControllableShip object and passes it player input.
    /// </summary>
    public class PCShipController : MonoBehaviour, IShipController {
        private bool connected;

        private IShip ship;



        // Monobehaviour
        //

        void Awake() {
            connected = false;
        }

        /// <summary>
        /// Check to see if the controller is doing anything, and if so pass that onto the ship.
        /// Adds rotational movement, and fires weapons. Does nothing if there is no ship registered
        /// or the controller is not connected.
        /// </summary>
        void Update() {

            if (ship == null) {
                return;
            }

            if (!connected) {
                return;
            }

            // shoot
            if (Input.GetButtonDown("Fire1")) {
                ship.Shoot();
            }

            // boost speed
            if (Input.GetButton("Fire2")) {
                ship.BoostSpeed();
            }

            // turn the ship
            ship.Turn(Input.GetAxis("Horizontal"));
        }


        // IShipController
        //

        public void Disconnect() {
            connected = false;
        }

        public void Connect() {
            connected = true;
        }

        public void Deregister(IShip ship) {
            if (this.ship == ship) {
                this.ship = null;
            }
        }

        public void Register(IShip ship) {
            if (this.ship == null) {
                this.ship = ship;
            }
        }
    }
}