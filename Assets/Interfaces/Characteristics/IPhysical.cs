using UnityEngine;

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
        void AddForce ( Vector3 force );

        /// <summary>
        /// Return the position of the object.
        /// </summary>
        /// <returns></returns>
        Vector3 GetPosition ();

        /// <summary>
        /// Set the ship to a position defined by a Vector3
        /// </summary>
        /// <returns></returns>
        void SetPosition ( Vector3 position );
    }
}
