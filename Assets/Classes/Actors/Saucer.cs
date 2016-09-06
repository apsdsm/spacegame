using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;
using System;

namespace SpaceGame.Actors
{
    [RequireComponent(typeof(Rigidbody))]
    public class Saucer : MonoBehaviour, IDestroyable, IEnemy
    {

        private enum State
        {
            Normal,
            Damaged,
            Destructing,
            Destroyed
        }

        [Tooltip("how much damage the object can take before it is destroyed")]
        public float health = 30.0f;

        [Tooltip("point at which the saucer starts to show damage effects")]
        public float criticalDamagePoint = 15.0f;

        [Tooltip("how far the player needs to be before the enemy will chase them")]
        public float chaseDistance = 10.0f;

        [Tooltip("the basic speed of the enemy")]
        public float cruiseSpeed = 15.0f;

        [Tooltip("how many points this enemy is worth")]
        public int points = 2000;

        [Tooltip("contains particle effect for impacts")]
        public GameObject impactEffect;

        [Tooltip("contains particle effect for damage smoke")]
        public GameObject damageSmokeEffect;

        [Tooltip("contains particle effect for destroy explosion")]
        public GameObject destroyEffect;

        [Tooltip("Spped at which object falls to earth after being destroyed")]
        public float dropSpeed = 4.0f;

        private State state = State.Normal;

        private IRegistryService registry;

        private IScoreService score;

        private Rigidbody rigid;

        private Ship ship;

        private IPlanet planet;

        private ParticleSystem destroyEffectSystem;

        void Awake()
        {
            registry = IOC.Resolve<IRegistryService>();
            score = IOC.Resolve<IScoreService>();

            rigid = GetComponent<Rigidbody>();
            rigid.useGravity = false;
            rigid.constraints = RigidbodyConstraints.FreezeRotation;
        }

        void Start()
        {
            ship = registry.LookUp<Ship>("Ship");
            planet = registry.LookUp<IPlanet>("Planet");
        }

        void Update()
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
            if (state == State.Destructing) {

                // drop the ship down towards the core of the planet
                Vector3 toPlanet = planet.core - transform.position;
                rigid.AddForce(toPlanet * (dropSpeed * Time.deltaTime));

                // if the particle effect is over, remove the saucer from the game
                if (destroyEffect != null) {
                    if (!destroyEffectSystem.GetComponent<ParticleSystem>().IsAlive(true)) {
                        state = State.Destroyed;
                        Destroy(gameObject);
                    }
                }
                    
            } else {

                if (ship == null) {
                    return;
                }

                // distance to player - calc the distance between two points on unit sphere, then multiply by the planet radius to get real distance
                float distanceToPlayer = Mathf.Acos(Vector3.Dot(transform.position.normalized, ship.transform.position.normalized)) * planet.surface.radius;

                Vector3 newPosition = transform.position;

                if (distanceToPlayer > chaseDistance) {
                    // project vector to player onto the saucer's X Z plane, then move towards that direction
                    Vector3 vectorToPlayer = (ship.transform.position - transform.position).normalized;
                    Vector3 projectedToPlayer = Vector3.ProjectOnPlane(vectorToPlayer, transform.up);

                    newPosition = transform.position + projectedToPlayer.normalized * cruiseSpeed * Time.deltaTime;
                }

                // adjust height to be over planet
                Vector3 heightNormalised = (newPosition - planet.core).normalized * planet.surface.radius;

                rigid.MovePosition(heightNormalised);
            }
        }

        /// <summary>
        /// The saucer takes damage.
        /// </summary>
        /// <param name="damage">ammount of damage that saucer will take</param>
        public void Damage(Damage damage)
        {
            if (state >= State.Destructing) {
                return;
            }

            health -= damage.ammount;

            if (impactEffect != null) {
                GameObject effect = Instantiate(impactEffect);
                effect.transform.parent = transform;
                effect.transform.position = transform.position;
            }

            if (health <= 0.0f) {

                // add points to score
                score.AddToScore(points);

                // turn off collisions
                GetComponent<SphereCollider>().enabled = false;

                // create and play destroy effect
                if (destroyEffect != null) {
                    GameObject effect = Instantiate(destroyEffect);
                    effect.transform.parent = transform;
                    effect.transform.position = transform.position;
                    destroyEffectSystem = effect.GetComponent<ParticleSystem>();
                }

                // set state to destructing
                state = State.Destructing;

                return;
            }

            if (health <= criticalDamagePoint && state < State.Damaged) {
                               
                if (damageSmokeEffect != null) {
                    GameObject effect = Instantiate(damageSmokeEffect);
                    effect.transform.parent = transform;
                    effect.transform.position = transform.position;
                }

                state = State.Damaged;
            }
        }

        /// <summary>
        /// Move saucer to location.
        /// </summary>
        /// <param name="location">moves to this location</param>
        public void MoveToLocation(Location location)
        {
            transform.position = location.position;
            transform.up = location.orientation;
        }
    }
}
