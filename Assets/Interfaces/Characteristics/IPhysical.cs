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
        /// The object's current position.
        /// </summary>
        Vector3 Position
        { get; set; }

        /// <summary>
        /// The object's current up axis
        /// </summary>
        Vector3 Up
        { get; set; }
    }
}
