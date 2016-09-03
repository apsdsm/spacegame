using UnityEngine;
using SpaceGame.Interfaces;
using SpaceGame.Behaviours;
using SpaceGame.Actors;
using System;

namespace SpaceGame.Factories
{
    public class EnemyFactory : MonoBehaviour, IEnemyFactory
    {

        [Tooltip("Saucer enemy")]
        public GameObject saucer;

        /// <summary>
        /// Create an enemy saucer and return a component that satisfies IEnemy.
        /// </summary>
        /// <returns></returns>
        public IEnemy CreateSaucer()
        {
            GameObject enemyGameObject = Instantiate(saucer);

            enemyGameObject.transform.parent = transform;
        
            IEnemy enemy = enemyGameObject.GetComponent<IEnemy>();

            return enemy;
        }
    }
}