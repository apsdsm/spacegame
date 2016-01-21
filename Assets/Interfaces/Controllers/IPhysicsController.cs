using UnityEngine;

namespace SpaceGame.Interfaces
{
    /// <summary>
    /// Interface for the ship agent class.
    /// </summary>
    public interface IPhysicsController
    {
        /// <summary>
        /// Add force to the ship.
        /// </summary>
        /// <param name="force"></param>
        void AddForce ( Vector3 force );

        /// <summary>
        /// Add relative force to the ship.
        /// </summary>
        /// <param name="vector">vector representation of added velocity</param>
        void AddRelativeForce ( Vector3 force );

        /// <summary>
        /// Add rotational velocity to the ship.
        /// </summary>
        /// <param name="vector">vector representation of added velocity</param>
        void AddRelativeTorque ( Vector3 torque );

        /// <summary>
        /// Provide the current position of the ship.
        /// </summary>
        Vector3 Position
        { get; }
    }
}
