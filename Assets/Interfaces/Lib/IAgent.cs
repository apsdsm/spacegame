using UnityEngine;

namespace SpaceGame.Interfaces
{
    /// <summary>
    /// In a lot of ways an IAgent is essentially a means of interacting with the transform
    /// </summary>
    public interface IAgent
    {
        /// <summary>
        /// Destroy the object containing the agent.
        /// </summary>
        void Destroy ();
    }
}
