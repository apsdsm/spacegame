using UnityEngine;
using SpaceGame.Interfaces;
using SpaceGame.Behaviours;
using System;

namespace SpaceGame.Factories
{
    public class CollectableFactory : MonoBehaviour, ICollectableFactory
    {
        [Tooltip("Collectable coin the player can pick up")]
        public GameObject coin;

        public ICollectable CreateCoin ()
        {
            GameObject newObject = Instantiate(coin);
            newObject.transform.parent = this.transform;
            ICollectable component = newObject.GetComponent<CollectableBehaviour>();
            return component;
        }
    }
}
