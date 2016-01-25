using UnityEngine;
using SpaceGame.Interfaces;
using System;

namespace SpaceGame.Actors
{
    public class Enemy : IPhysical
    {

        // agent
        IAgent agent;

        // controllers
        ITransformController transform;
        IPhysicsController physics;

        /// <summary>
        /// Create a new enemy.
        /// </summary>
        /// <param name="agent">controlling agent</param>
        public Enemy ( IAgent agent, 
                       ITransformController transform,
                       IPhysicsController physics )
        {
            // agent
            this.agent = agent;

            // controllers
            this.transform = transform;
            this.physics = physics;
        }

        /// <summary>
        /// Returns the enemy's current position.
        /// </summary>
        /// <returns></returns>
        public Vector3 GetPosition ()
        {
            return transform.Position;
        }

        /// <summary>
        /// Set the enemy's position.
        /// </summary>
        /// <param name="position">position as Vector3</param>
        public void SetPosition ( Vector3 position )
        {
            transform.Position = position;
        }

        /// <summary>
        /// Add force to the enemy.
        /// </summary>
        /// <param name="force"></param>
        public void AddForce ( Vector3 force )
        {
            physics.AddForce( force );
        }

    }
}
