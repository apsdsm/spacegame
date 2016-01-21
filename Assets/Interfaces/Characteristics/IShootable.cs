using UnityEngine;

namespace SpaceGame.Interfaces
{
    /// <summary>
    /// A Physics object can be affected by external physics forces like gravity.
    /// </summary>
    public interface IShootable
    {
        /// <summary>
        /// Shoot the shootable thing in a given direction
        /// </summary>
        /// <param name="direction"></param>
        void Shoot ( Vector3 startingPosition, Vector3 direction );      
    }
}
