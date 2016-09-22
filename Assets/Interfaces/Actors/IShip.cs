using UnityEngine;
using SpaceGame.Events;

namespace SpaceGame.Interfaces
{
    public interface IShip
    {
            
        /// <summary>
        /// Turn the ship left or right.
        /// </summary>
        /// <param name="thrust">thrust to add. Negative is left, positive is right.</param>
        void Turn(float thrust);

        /// <summary>
        /// Fires the ships weapons.
        /// </summary>
        void Shoot();

        /// <summary>
        /// Increase the ship's speed.
        /// </summary>
        void BoostSpeed();

        /// <summary>
        /// Return the ship's location
        /// </summary>
        Location location { get; }
                
        /// <summary>
        /// Provide access to the underlying object's transform.
        /// </summary>
        Transform transform { get; }

        /// <summary>
        /// Called when speed of ship changes.
        /// </summary>
        event SpeedChangedEvent onSpeedChanged;
    }
}
