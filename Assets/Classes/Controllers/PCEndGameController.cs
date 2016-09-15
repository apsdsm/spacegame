using UnityEngine;
using UnityEngine.SceneManagement;
using SpaceGame.Interfaces;

namespace SpaceGame.Controllers {

    /// <summary>
    /// If the user presses the fire button will go back to the main menu.
    /// </summary>
    class PCEndGameController : MonoBehaviour, IEndGameController {

        private bool connected;



        // MonoBehaviour
        //

        void Awake() {
            connected = false;
        }

        /// <summary>
        /// If the user presses the fire button will load the main menu.
        /// </summary>
        void Update() {
            if (!connected) {
                return;
            }

            if (Input.GetButtonDown("Fire1")) {
                SceneManager.LoadScene("MainMenu");
            }
        }



        // ILoseGameController
        //

        public void Disconnect() {
            connected = false;
        }

        public void Connect() {
            connected = true;
        }
    }
}
