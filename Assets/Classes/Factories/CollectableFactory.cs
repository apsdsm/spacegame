using UnityEngine;
using SpaceGame.Interfaces;
using System;

namespace SpaceGame.Factories
{
    class CollectableFactory : MonoBehaviour, ICollectableFactory
    {
        public ICollectable CreateCoin ()
        {
            throw new NotImplementedException();
        }
    }
}
