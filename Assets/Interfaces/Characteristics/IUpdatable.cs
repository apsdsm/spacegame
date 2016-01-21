using UnityEngine;

namespace SpaceGame.Interfaces
{
    /// <summary>
    /// A Physics object can be affected by external physics forces like gravity.
    /// </summary>
    public interface IUpdatable
    {
        /// <summary>
        /// Set the ship to a position defined by a Vector3
        /// </summary>
        /// <returns></returns>
        void Update ( float deltaTime = 0.0f );
    }
}
