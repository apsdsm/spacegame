using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;
using System;

namespace SpaceGame.Behaviours
{
    class PhysicalBehaviour : MonoBehaviour, IPhysical
    {
        private IRegistryService registry;

        private IPlanet planet;

        private Vector3 velocity;

        private Rigidbody rigid;

        [Tooltip("the fastest speed the object can reach")]
        public float topSpeed = 10.0f;

        void Awake ()
        {
            registry = IOC.Resolve<IRegistryService>();

        }

        void Start ()
        {
            // get references
            planet = registry.LookUp<IPlanet>("Planet");

            // get components
            rigid = GetComponent<Rigidbody>();
            rigid.constraints = RigidbodyConstraints.FreezeRotation;
            rigid.useGravity = false;
        }

        void Update ()
        {
            Vector3 correctUp = (transform.position - planet.core).normalized;
            Vector3 currentUp = transform.up;

            Quaternion correctRotation = Quaternion.FromToRotation(currentUp, correctUp) * transform.rotation;

            transform.rotation = Quaternion.Slerp(transform.rotation, correctRotation, 10 * Time.deltaTime);        
        }

        void FixedUpdate ()
        {
            Vector3 gravity = (planet.core - transform.position).normalized * (10.0f + planet.GetDistanceFromSurface(transform.position));

            rigid.AddForce(gravity);

            if (rigid.velocity.magnitude > topSpeed) {
                rigid.velocity = rigid.velocity.normalized * topSpeed;
            }
        }

        // IPhysical.AddForce
        public void AddForce (Vector3 force)
        {
            rigid.AddForce(force);
        }


        // IPhysical.MoveToLocation
        public void MoveToLocation (Location location)
        {
            transform.position = location.position;
            transform.up = location.orientation;
        }

        // IPhysical.GetCurrentLocation
        public Location GetCurrentLocation ()
        {
            return new Location(){position = transform.position, orientation = transform.up};
        }

        // IPhysical.GetVelocity
        public Vector3 GetVelocity ()
        {
            return velocity;
        }
    }
}
