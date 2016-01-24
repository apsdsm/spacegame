using UnityEngine;

namespace SpaceGame.Interfaces
{
    /// <summary>
    /// In a lot of ways an IAgent is essentially a means of interacting with the transform
    /// </summary>
    public interface IAgent
    {
        /// <summary>
        /// Transform current position.
        /// </summary>
        Vector3 Position
        { get; set; }

        /// <summary>
        /// Transform current rotation.
        /// </summary>
        Quaternion Rotation
        { get; set; }

        /// <summary>
        /// Transform forward vector.
        /// </summary>
        Vector3 Forward
        { get; set; }

        /// <summary>
        /// Transform up vector.
        /// </summary>
        Vector3 Up
        { get; set; }

        /// <summary>
        /// Transform right vector.
        /// </summary>
        Vector3 Right
        { get; set; }

        /// <summary>
        /// Destroy the object containing the agent.
        /// </summary>
        void Destroy ();
    }
}
