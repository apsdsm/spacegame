using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;
using System;

namespace SpaceGame.Controllers
{
    /// <summary>
    /// The ship agent is responsible for carrying out all the interactions 
    /// between its controller and the game world.
    /// 
    /// Notes:
    /// the ship also needs a physics material to reduce friction with the world
    /// the ship probably needs a box collider to avoid rolling
    /// the ship should apply force based on the forward vector
    /// </summary>
    [ RequireComponent( typeof( Rigidbody ) )]
    public class PhysicsController : MonoBehaviour, IPhysicsController
    {
        // components
        private Rigidbody rigidBody;       


        /// <summary>
        /// Get a reference to the rigid body and turn off gravity.
        /// </summary>
        void Start ()
        {
            rigidBody = gameObject.GetComponent<Rigidbody>();
            rigidBody.useGravity = false;
        }


        /// <summary>
        /// Adds relative force to the ship.
        /// </summary>
        /// <param name="vector"></param>
        public void AddRelativeForce (Vector3 direction )
        {
            rigidBody.AddRelativeForce( direction );
        }


        /// <summary>
        /// Adds rotational velocity to the ship
        /// </summary>
        /// <param name="direction"></param>
        public void AddRelativeTorque ( Vector3 direction )
        {
            rigidBody.AddRelativeTorque( direction );
        }


        /// <summary>
        /// Adds force to the ship.
        /// </summary>
        /// <param name="force"></param>
        public void AddForce ( Vector3 force )
        {
            rigidBody.AddForce( force );
        }


        /// <summary>
        /// Returns the ship's current position in space
        /// </summary>
        public Vector3 Position
        {
            get { return transform.position; }
        }
    }
}