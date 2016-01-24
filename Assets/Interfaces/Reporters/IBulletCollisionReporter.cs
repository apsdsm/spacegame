using UnityEngine;

namespace SpaceGame.Interfaces
{
    /// <summary>
    /// Interface for the ship factory class.
    /// </summary>
    public interface IBulletCollisionReporter
    {
        /// <summary>
        /// If the bullet collided with any phyical object, it gets returned by this method.
        /// </summary>
        IPhysical GetCollisions ( Vector3 trajectoryStart, Vector3 trajectory, float length );
    }
}
