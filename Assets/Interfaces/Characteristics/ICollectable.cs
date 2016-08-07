using UnityEngine;

namespace SpaceGame.Interfaces
{
    /// <summary>
    /// A collectable object can be picked up by the player.
    /// </summary>
    public interface ICollectable
    {
        /// <summary>
        /// Move the object to the specified locations
        /// </summary>
        /// <param name="location">where to move the object</param>
        void MoveToLocation (Location location);
    }
}
