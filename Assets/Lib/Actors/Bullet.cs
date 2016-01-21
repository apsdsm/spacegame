using System;
using SpaceGame.Interfaces;
using UnityEngine;

namespace SpaceGame.Actors
{
    [Serializable]
    public class Bullet : IUpdatable, IShootable
    {
        IAgent agent;
        
        [Tooltip("speed that the bullet will travel at.")]
        public float speed = 20.0f;

        public Bullet ( IAgent agent )
        {
            this.agent = agent;
        }

        /// <summary>
        /// Set the bullet in a specific position and orientation.
        /// </summary>
        /// <param name="direction">the direction to shoot the bullet</param>
        public void Shoot ( Vector3 startingPosition, Vector3 direction )
        {
            agent.Position = startingPosition;
            agent.Forward = direction;
        }

        /// <summary>
        /// Updates the bullet - shooting it along its trajectory.
        /// </summary>
        /// <param name="deltaTime">time passed since last update</param>
        public void Update ( float deltaTime = 0.0f )
        {
            agent.Position = agent.Position + agent.Forward * speed * deltaTime;
        }
    }
}