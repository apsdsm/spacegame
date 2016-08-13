using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;
using System;

namespace SpaceGame.Actors
{
    [RequireComponent(typeof(Rigidbody))]
    public class Saucer : MonoBehaviour, IDestroyable
    {
        [Tooltip("how much damage the object can take before it is destroyed")]
        public float health = 10.0f;

        public void Damage(Damage damage)
        {
            health -= damage.ammount;

            if (health <= 0.0f) {
                Debug.Log("I was destroyed");
                Destroy(gameObject);
            }
            else {
                Debug.Log("I was damaged");
            }
        }
    }
}
