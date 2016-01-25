using System;
using SpaceGame.Interfaces;
using UnityEngine;

namespace SpaceGame.Actors
{
    [Serializable]
    public class Bullet : IUpdatable, IShootable
    {
        IAgent agent;
        ITransformController transform;
        IBulletCollisionReporter collisions;
        
        [Tooltip("speed that the bullet will travel at.")]
        public float speed = 20.0f;

        [Tooltip("maximum life time for bullet.")]
        public float lifespan = 3.0f;

        // time that has ellapsed since bullet was fired
        private float timeSinceFired = 0.0f;

        // true while bullet is shooting
        private bool isShooting = false;

        public Bullet ( IAgent agent,
                        ITransformController transform,
                        IBulletCollisionReporter collisions )
        {
            this.agent = agent;
            this.transform = transform;
            this.collisions = collisions;
            
        }

        /// <summary>
        /// Set the bullet in a specific position and orientation.
        /// </summary>
        /// <param name="direction">the direction to shoot the bullet</param>
        public void Shoot ( Vector3 startingPosition, Vector3 direction )
        {
            transform.Position = startingPosition;
            transform.Forward = direction;
            isShooting = true;
        }

        /// <summary>
        /// If the bullet is shooting, will move it along its trajectory. If the bullet will hit
        /// any enemy this update, will damage that enemy.
        /// </summary>
        /// <param name="deltaTime">time passed since last update</param>
        public void Update ( float deltaTime = 0.0f )
        {
            if ( !isShooting )
            {
                return;
            }

            timeSinceFired += deltaTime;

            if ( timeSinceFired >= lifespan )
            {
                isShooting = false;
                agent.Destroy();
            }
            else
            {

                transform.Position = transform.Position + transform.Forward * speed * deltaTime;
                // check for collisions
            }
        }
    }
}