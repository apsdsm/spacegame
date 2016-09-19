using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;
using System;
using SpaceGame.Events;

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

        [Tooltip("Speed at which object falls to earth after being destroyed")]
        public float dropSpeed = 4.0f;


        // services
        IRegistryService registry;
        IScoreService score;

        // factories
        ICollectableFactory collectables;
                
        // actors
        IShip ship;
        IPlanet planet;

        // move saucer around game space
        Rigidbody rigid;

        // internal reference to destroy effect
        ParticleSystem destroyEffectSystem;

        // current enemy state
        State state = State.Normal;

        // variables to cut back on memory allocation
        Vector3 currentVectorToPlayer;
        Vector3 currentProjectedToPlayer;
        float currentDistanceToPlayer;



        //////////////////////////////////////////////////////////////////////////////////
        // Monobehaviour Events
        //

        void Awake()
        {
            registry = IOC.Resolve<IRegistryService>();

            collectables = IOC.Resolve<ICollectableFactory>();

            score = IOC.Resolve<IScoreService>();

            rigid = GetComponent<Rigidbody>();
            rigid.useGravity = false;
            rigid.constraints = RigidbodyConstraints.FreezeRotation;
        }

        void Start()
        {
            ship = registry.LookUp<IShip>("Ship");

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
                OnDestructing();
                return;
            }

            if (ship == null) {
                return;
            }

            // distance to player - calc the distance between two points on unit sphere, then multiply by the planet radius to get real distance
            currentDistanceToPlayer = Mathf.Acos(Vector3.Dot(transform.position.normalized, ship.location.position.normalized)) * planet.surface.radius;

            // deafult starting position is current position
            Vector3 targetPosition = transform.position;

            // if player further out than chase distance, update target position
            if (currentDistanceToPlayer > chaseDistance) {

                // a vector directly to the player.
                currentVectorToPlayer = (ship.location.position - transform.position).normalized;

                // the vector projected onto the saucer's XZ plane
                currentProjectedToPlayer = Vector3.ProjectOnPlane(currentVectorToPlayer, transform.up).normalized;

                // calculate movement in projected direction
                targetPosition = transform.position + currentProjectedToPlayer * cruiseSpeed * Time.deltaTime;

                // normalize height
                targetPosition = (targetPosition - planet.core).normalized * planet.surface.radius;

            }
            
            rigid.MovePosition(targetPosition);
        }



        //////////////////////////////////////////////////////////////////////////////////
        // Events
        //
        
        /// <summary>
        /// Called when enemy is destroyed. See IEnemy.
        /// </summary>
        public event EnemyDestroyedEvent destroyed;



        //////////////////////////////////////////////////////////////////////////////////
        // Public
        //

        /// <summary>
        /// Damages the saucer by the given ammount. See IDamageable.
        /// </summary>
        /// <param name="damage">damage information</param>
        public void Damage(Damage damage)
        {
            // if this object is already destructing or destroyed, don't do anything
            if (state >= State.Destructing) {
                return;
            }

            health -= damage.ammount;

            if (impactEffect != null) {
                GameObject effect = Instantiate(impactEffect);
                effect.transform.parent = transform;
                effect.transform.position = transform.position;
            }

            if (health <= criticalDamagePoint && state < State.Damaged) {

                if (damageSmokeEffect != null) {
                    GameObject effect = Instantiate(damageSmokeEffect);
                    effect.transform.parent = transform;
                    effect.transform.position = transform.position;
                }

                state = State.Damaged;
            }

            if (health <= 0.0f) {

                // add points to score
                score.AddToScore(points);

                // turn off collisions
                GetComponent<SphereCollider>().enabled = false;

                // drop some energy
                ICollectable energyBall = collectables.CreateEnergyBall();
                energyBall.MoveToLocation(new Location(transform.position, transform.up));

                // create and play destroy effect
                if (destroyEffect != null) {
                    GameObject effect = Instantiate(destroyEffect);
                    effect.transform.parent = transform;
                    effect.transform.position = transform.position;
                    destroyEffectSystem = effect.GetComponent<ParticleSystem>();
                }

                // set state to destructing
                state = State.Destructing;

                // let subscribers know it was destroyed
                OnDestroyed();
            }
        }
        
        /// <summary>
        /// Move the saucer to a new location. See IEnemy.
        /// </summary>
        /// <param name="location">new lcoation</param>
        public void MoveToLocation(Location location)
        {
            transform.position = location.position;
            transform.up = location.orientation;
        }



        //////////////////////////////////////////////////////////////////////////////////
        // Private
        //

        /// <summary>
        /// While saucer is destructing it will start the explosion particle effect. 
        /// When the effect is over, it will remove itself from the game.
        /// </summary>
        private void OnDestructing()
        {
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
        }

        /// <summary>
        /// Informs subscribers that this enemy has been destroyed.
        /// </summary>
        private void OnDestroyed()
        {
            if (destroyed != null) {
                destroyed(this);
            }
        }
    }
}
