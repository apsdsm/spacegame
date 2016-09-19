using UnityEngine;
using SpaceGame.Interfaces;

namespace SpaceGame.Actors
{
    public class Projectile : MonoBehaviour, IShootable
    {

        [Tooltip("The speed at which the projectile moves.")]
        public float speed = 40.0f;

        [Tooltip("The amount of time before the projectile stops.")]
        public float lifeSpan = 2.0f;

        [Tooltip("The amount of damage it imparts to other obejcts.")]
        public float damage = 10.0f;

        // true if bullet is currently being shot or otherwise moving
        private bool active = false;

        // amount of time since projectile was fired
        private float timeSinceFired = 0.0f;

        // the point around which objects will rotate
        private Vector3 gravityCore;

        // reference to projectile's own rigid body
        private Rigidbody rigid;


        void Awake()
        {
            rigid = GetComponent<Rigidbody>();
            rigid.useGravity = false;
            rigid.isKinematic = true;
        }

        // Update is called once per frame
        void Update ()
        {
            if (!active) {
                return;
            }

            timeSinceFired += Time.deltaTime;

            if (timeSinceFired >= lifeSpan) {
                Destroy(gameObject);
                return;
            }

            Vector3 worldUp = (transform.position - gravityCore).normalized;

            Vector3 rotationAxis = Vector3.Cross(transform.forward, worldUp);

            Vector3 correctForward = Vector3.Cross(worldUp, rotationAxis);

            transform.forward = correctForward;
               
            Debug.DrawRay(transform.position, transform.up * 2.0f, Color.red);
            Debug.DrawRay(transform.position, transform.forward * 2.0f, Color.blue);

        }

        // Called at fixed intervals for physics commands
        void FixedUpdate()
        {
            if (!active) {
                return;
            }

            Vector3 newPosition = transform.position + (transform.forward * speed * Time.deltaTime);

            rigid.MovePosition(newPosition);

        }

        // Shoot the projectile in this direction
        public void Shoot (Vector3 startingPosition, Vector3 direction, Vector3 gravityCore)
        {
            transform.position = startingPosition;
            transform.forward = direction;
            this.gravityCore = gravityCore;
            active = true;
        }

        // When the projectile enters something, damage it
        public void OnTriggerEnter(Collider other)
        {
            IDestroyable destroyable = other.GetComponent<IDestroyable>() as IDestroyable;

            if (destroyable != null) {
                destroyable.Damage(new Damage(){ direction = transform.forward, ammount = damage, shootable = this });
            }
        }

    }
}
