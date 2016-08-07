using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;
using System;

namespace SpaceGame.Behaviours
{
    class CollectableBehaviour : MonoBehaviour, ICollectable
    {
        public void MoveToLocation (Location location) 
        {
            transform.position = location.position;
            transform.up = location.orientation;
        }
    }
}
