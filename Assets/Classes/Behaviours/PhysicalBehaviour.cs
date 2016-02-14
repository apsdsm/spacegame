using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;

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

        public void AddForce (Vector3 force)
        {
            rigid.AddForce(force);
        }

        public Vector3 Position
        {
            set { transform.position = value; }

            get { return transform.position; }
        }
        
        public Vector3 Up
        {
            set { transform.up = value; }

            get { return transform.up; }
        }
    }
}
