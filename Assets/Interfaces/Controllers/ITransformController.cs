using UnityEngine;

namespace SpaceGame.Interfaces
{
    public interface ITransformController
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
    }
}
