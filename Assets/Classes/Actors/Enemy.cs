using UnityEngine;
using SpaceGame.Interfaces;
using SpaceGame.Exceptions;
using Fletch;
using System;

namespace SpaceGame.Actors
{
    [RequireComponent(typeof(Rigidbody))]
    class Enemy : MonoBehaviour, IPhysical
    {

        private Rigidbody rigid;

        void Awake()
        {
            rigid = GetComponent<Rigidbody>();
        }

        public void AddForce (Vector3 force)
        {
            rigid.AddForce(force);
        }

        public Vector3 GetPosition ()
        {
            return transform.position;
        }

        public void SetPosition (Vector3 position)
        {
            transform.position = position;
        }
    }
}
