using System;
using UnityEngine;
using SpaceGame.Interfaces;

namespace SpaceGame.Factories
{
    public class ControllableFactory : MonoBehaviour, IControllableFactory
    {

        [Tooltip("Cotnrollable Ship")]
        public GameObject ship;


        /// <summary>
        /// Create a new controllable ship.
        /// </summary>
        /// <returns></returns>
        public IControllable CreateShip()
        {
            if (ship == null) {
                throw new MissingFieldException("require ship field be set");
            }

            GameObject shipGameObject = Instantiate(ship);

            shipGameObject.transform.parent = transform;

            IControllable controllable = shipGameObject.GetComponent<IControllable>();

            return controllable;
        }
    }
}