using UnityEngine;
using SpaceGame.Interfaces;
using SpaceGame.Behaviours;
using SpaceGame.Actors;
using System;
using SpaceGame.Events;

namespace SpaceGame.Factories
{
    public class EnemyFactory : MonoBehaviour, IEnemyFactory
    {

        [Tooltip("Saucer enemy")]
        public GameObject saucer;
        


        // IEnemyFactory
        //

        public IEnemy CreateSaucer()
        {
            GameObject enemyGameObject = Instantiate(saucer);

            enemyGameObject.transform.parent = transform;
        
            IEnemy enemy = enemyGameObject.GetComponent<IEnemy>();

            return enemy;
        }
    }
}