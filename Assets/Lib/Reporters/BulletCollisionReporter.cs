using UnityEngine;
using SpaceGame.Actors;
using SpaceGame.Agents;
using SpaceGame.Interfaces;

namespace SpaceGame.Reporters
{
    class BulletCollisionReporter : MonoBehaviour, IBulletCollisionReporter
    {
        
        /// <summary>
        /// Return the radius of the sphere collider
        /// </summary>
        public IPhysical GetCollisions ( Vector3 trajectoryStart, Vector3 trajectory, float length )
        {
            // check
            

            return null;
        }
    }
}
