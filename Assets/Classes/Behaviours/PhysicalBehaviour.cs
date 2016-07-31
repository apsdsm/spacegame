using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;
using System;

namespace SpaceGame.Behaviours
{
    [RequireComponent(typeof(Rigidbody))]
    class PhysicalBehaviour : MonoBehaviour, IPhysical
    {
        private Rigidbody rigid;

        private IGravityService gravity;

        void Awake ()
        {
            gravity = IOC.Resolve<IGravityService>();

            gravity.Register(this);
        }

        void OnDestroy ()
        {
            gravity.Deregister(this);
        }

        void Start ()
        {
            rigid = GetComponent<Rigidbody>();

            rigid.useGravity = false;
        }

        /// <summary>
        /// Add force to the object.
        /// </summary>
        /// <param name="force"></param>
        public void AddForce (Vector3 force)
        {
            rigid.AddForce(force);
        }

        /// <summary>
        /// Move the object to a location.
        /// </summary>
        /// <param name="location"></param>
        public void MoveToLocation (Location location)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Location GetCurrentLocation ()
        {
            Location location = new Location();
            location.position = transform.position;
            location.orientation = transform.up;

            return location;
        }
    }
}
