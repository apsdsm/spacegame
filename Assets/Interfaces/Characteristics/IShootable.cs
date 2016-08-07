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
        /// <param name="startingPosition">where the projectile starts</param>
        /// <param name="direction">what direction it's traveling in</param>
        /// <param name="gravityCore">the position of what it's orbiting</param>
        void Shoot ( Vector3 startingPosition, Vector3 direction, Vector3 gravityCore );      
    }
}
