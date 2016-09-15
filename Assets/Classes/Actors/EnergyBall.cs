using UnityEngine;

using SpaceGame.Interfaces;
using System;

using Fletch;

namespace SpaceGame.Actors {
    
    /// <summary>
    /// A ball of energy that can be picked up to extend game time.
    /// </summary>
    class EnergyBall : MonoBehaviour, ICollectable {

        [Tooltip("Ammount of time to add when picked up")]
        public int addSeconds = 2;

        private ITimeService time;

        void Awake() {
            time = IOC.Resolve<ITimeService>();
        }

        void OnTriggerEnter(Collider other) {
            // add more time to the time service
            time.AddSeconds(addSeconds);

            // remove self from the game
            Destroy(gameObject);
        }

        public void MoveToLocation(Location location) {
            transform.position = location.position;
            transform.up = location.orientation;
        }
    }
}
