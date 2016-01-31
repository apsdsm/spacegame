using UnityEngine;
using SpaceGame.Interfaces;
using SpaceGame.Actors;

namespace SpaceGame.Factories
{
    public class PhysicalFactory : MonoBehaviour, IPhysicalFactory
    {

        [Tooltip("The ship that spawns for the player")]
        public GameObject playerShip;

        [Tooltip("The ship that spawns for enemies")]
        public GameObject enemyShip;

        /// <summary>
        /// Instantiate and return a Player Ship object.
        /// </summary>
        /// <returns></returns>
        public IPhysical CreatePlayerShip ()
        {
            if ( playerShip != null )
            {
                GameObject gameObject = Instantiate( playerShip );
                IPhysical component = gameObject.GetComponent<Ship>();
                return component;
            }

            return null;
        }


        /// <summary>
        /// Instantiate and return an Enemy Ship object.
        /// </summary>
        /// <returns></returns>
        public IPhysical CreateEnemyShip ()
        {
            if ( enemyShip != null )
            {
                GameObject gameObject = Instantiate( enemyShip );
                IPhysical component = gameObject.GetComponent<Enemy>();
                return component;
            }

            return null;
        }
    }
}