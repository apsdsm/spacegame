using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Fletch;
using SpaceGame.Interfaces;

namespace SpaceGame.UI.Game {
    public class RadarWidget : MonoBehaviour {

        [Tooltip("the game obejct that will be used to show enemy locations")]
        public GameObject enemyPointer;

        [Tooltip("the distance at which enemies are on the radar edge")]
        public float radarMaxRange = 20.0f;

        List<EnemyPointerWidget> pointers;

        IRegistryService registry;

        IShip ship;

        IEnemyFactory enemyFactory;

        Vector3 vectorToEnemy;
        Vector3 projectedToEnemy;
        Vector3 localSpaceProjected;
        Vector3 positionOnRadar;

        float radius;

        void Awake() {
            radius = GetComponent<SphereCollider>().radius;

            pointers = new List<EnemyPointerWidget>();

            registry = IOC.Resolve<IRegistryService>();

            enemyFactory = IOC.Resolve<IEnemyFactory>();

            enemyFactory.onEnemyCreated += OnEnemyCreated;
        }

        void Start() {
            ship = registry.LookUp<IShip>("Ship");
        }

        void Update() {
            UpdatePointerPositions();
        }

        /// <summary>
        /// For each pointer, get a vector from the ship to the enemy represented by the pointer,
        /// then project that onto the ship's lateral plane. Convert that from world space to local
        /// space to get a vector we can use to position the pointer on the radar.
        /// 
        /// If the distance between the player and the enemy is greater than `radarMaxRange` then 
        /// the pointer appears on the edge of the radar. Otherwise the distance is expressed in a
        /// range of [0,radius], where radius is the radius of the sphere collider associated with
        /// the radar.
        /// </summary>
        private void UpdatePointerPositions() {
            foreach (EnemyPointerWidget pointer in pointers) {
                vectorToEnemy = pointer.enemy.transform.position - ship.transform.position;
                projectedToEnemy = Vector3.ProjectOnPlane(vectorToEnemy, ship.transform.up).normalized;
                localSpaceProjected = ship.transform.InverseTransformDirection(projectedToEnemy);

                float distanceToEnemy = vectorToEnemy.sqrMagnitude;

                if (distanceToEnemy >= radarMaxRange) {
                    distanceToEnemy = radius;
                } else {
                    distanceToEnemy = (distanceToEnemy / radarMaxRange) * radius;
                }

                positionOnRadar = localSpaceProjected * distanceToEnemy;

                pointer.transform.localPosition = positionOnRadar;
            }
        }

        /// <summary>
        /// Add a new pointer for this enemy.
        /// </summary>
        /// <param name="enemy">will make pointer for this enemy</param>
        void OnEnemyCreated(IEnemy enemy) {
            GameObject pointerObject = Instantiate(enemyPointer);

            EnemyPointerWidget pointer = pointerObject.GetComponent<EnemyPointerWidget>();
            
            pointer.enemy = enemy;
            pointer.transform.parent = transform;
            pointer.transform.position = Vector3.zero;

            enemy.destroyed += OnEnemyDestroyed;

            pointers.Add(pointer);
        }

        /// <summary>
        /// Remove the enemy pointer from the radar.
        /// </summary>
        /// <param name="enemy">will remove pointer for this enemy</param>
        void OnEnemyDestroyed(IEnemy enemy) {
            EnemyPointerWidget pointer = pointers.Find(x => x.enemy == enemy);

            Destroy(pointer.gameObject);

            pointers.Remove(pointer);
        }
    }
}
