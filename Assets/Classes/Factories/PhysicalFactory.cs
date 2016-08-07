using UnityEngine;
using SpaceGame.Interfaces;
using SpaceGame.Behaviours;
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
            return Create(playerShip);
        }


        /// <summary>
        /// Instantiate and return an Enemy Ship object.
        /// </summary>
        /// <returns></returns>
        public IPhysical CreateEnemyShip ()
        {
            return Create(enemyShip);
        }


        /// <summary>
        /// Create an object and return it, or null if the template is not set.
        /// </summary>
        /// <param name="template">thing to create</param>
        /// <returns>instantiated thing</returns>
        private IPhysical Create (GameObject template)
        {
            if (template != null)
            {
                GameObject newObject = Instantiate(template);
                newObject.transform.parent = this.transform;
                IPhysical component = newObject.GetComponent<PhysicalBehaviour>();
                return component;
            }

            return null;
        }
    }
}