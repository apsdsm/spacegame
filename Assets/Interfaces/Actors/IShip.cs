using UnityEngine;

namespace SpaceGame.Interfaces
{
    public interface IShip
    {
        /// <summary>
        /// Fire the forward or backward thrusters of the ship, causing it to 
        /// move on the longitudinal axis.
        /// </summary>
        /// <param name="thrust">thrust to add</param>
        /// <returns></returns>
        void AddLongitudinalThrust(float thrust);

        /// <summary>
        /// Fires the left or right thrusters of the ship, causing it to rotate.
        /// </summary>
        /// <param name="thrust">thrust to add</param>
        void AddRotationalThrust(float thrust);

        /// <summary>
        /// Fires the ships weapons.
        /// </summary>
        void Shoot();

        /// <summary>
        /// Return the ship's location
        /// </summary>
        Location location { get; }
    }
}
