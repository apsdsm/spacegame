using UnityEngine;
using SpaceGame.Interfaces;
using SpaceGame.Events;
using System;

namespace SpaceGame.Factories {
    public class EnemyFactory : MonoBehaviour, IEnemyFactory {

        [Tooltip("Saucer enemy")]
        public GameObject saucer;


        /// <summary>
        /// Call when a new enemy is created. See IEnemyFactory.
        /// </summary>
        public event EnemyCreatedEvent onEnemyCreated;


        /// <summary>
        /// Creates a new Saucer object. See IEnemyFactory.
        /// </summary>
        /// <returns>enemy that was created</returns>
        public IEnemy CreateSaucer() {
            GameObject enemyGameObject = Instantiate(saucer);

            enemyGameObject.transform.parent = transform;

            IEnemy enemy = enemyGameObject.GetComponent<IEnemy>();

            OnEnemyCreated(enemy);

            return enemy;
        }


        /// <summary>
        /// Triggers the onEnemyCreated event.
        /// </summary>
        /// <param name="enemy">reference to enemy that was created.</param>
        private void OnEnemyCreated(IEnemy enemy) {
            if (onEnemyCreated != null) {
                onEnemyCreated(enemy);
            }
        }

    }
}