using UnityEngine;
using SpaceGame.Interfaces;

namespace SpaceGame.Factories
{
    public class CollectableFactory : MonoBehaviour, ICollectableFactory
    {
        [Tooltip("Energy ball the player can pick up")]
        public GameObject energyBall;

        public ICollectable CreateEnergyBall ()
        {
            GameObject newObject = Instantiate(energyBall);
            newObject.transform.parent = this.transform;
            ICollectable component = newObject.GetComponent<ICollectable>();
            return component;
        }
    }
}
