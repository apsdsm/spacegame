using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;
using System;

namespace SpaceGame.Actors
{
    [RequireComponent(typeof(Rigidbody))]
    public class Saucer : MonoBehaviour, IDestroyable
    {
        [Tooltip("how much damage the object can take before it is destroyed")]
        public float health = 10.0f;

        public float acceleration = 20.0f;

        private float speed = 2.0f;

        private IRegistryService registry;

        private Rigidbody rigid;

        private Ship ship;

        private IPlanet planet;

        void Awake()
        {
            registry = IOC.Resolve<IRegistryService>();

            rigid = GetComponent<Rigidbody>();
            rigid.useGravity = false;
            rigid.constraints = RigidbodyConstraints.FreezeRotation;
        }

        void Start()
        {
            ship = registry.LookUp<Ship>("Ship");
            planet = registry.LookUp<IPlanet>("Planet");
        }
            
        void Update ()
        {
            // get the current up angle and the correct up angle
            Vector3 correctUp = (transform.position - planet.core).normalized;
            Vector3 currentUp = transform.up;

            // get quaternion representing the correct rotation
            Quaternion correctRotation = Quaternion.FromToRotation(currentUp, correctUp) * transform.rotation;

            // slerp towards the correct rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, correctRotation, 10 * Time.deltaTime);   
        }

        void FixedUpdate()
        {
            // project vector to player onto the saucer's X Z plane, then move towards that direction
            Vector3 vectorToPlayer = (ship.transform.position - transform.position).normalized;
            Vector3 projectedToPlayer = Vector3.ProjectOnPlane(vectorToPlayer, transform.up);
            Vector3 newPosition = transform.position + projectedToPlayer.normalized * speed * Time.deltaTime;
            rigid.MovePosition(newPosition);

            // calculte gravity
            Vector3 gravity = (planet.core - transform.position).normalized * (10.0f + planet.GetDistanceFromSurface(transform.position));
            rigid.AddForce(gravity);
        }

        public void Damage(Damage damage)
        {
            health -= damage.ammount;

            if (health <= 0.0f) {
                Debug.Log("I was destroyed");
                Destroy(gameObject);
            }
            else {
                Debug.Log("I was damaged");
            }
        }
    }
}
