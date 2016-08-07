using UnityEngine;
using SpaceGame;

namespace SpaceGame.Interfaces
{
    /// <summary>
    /// A Physics object can be affected by external physics forces like gravity.
    /// </summary>
    public interface IPhysical
    {
        /// <summary>
        /// Add force to the object.
        /// </summary>
        /// <param name="force"></param>
        void AddForce (Vector3 force);

        /// <summary>
        /// Move the object to the specified locations
        /// </summary>
        /// <param name="location">where to move the object</param>
        void MoveToLocation (Location location);

        /// <summary>
        /// Get the current location of the object.
        /// </summary>
        /// <returns>Location</returns>
        Location GetCurrentLocation ();

    }
}
