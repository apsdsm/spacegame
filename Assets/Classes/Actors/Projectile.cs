using UnityEngine;
using SpaceGame.Interfaces;
using System;

namespace SpaceGame.Actors
{
    public class Projectile : MonoBehaviour, IShootable
    {

        [Tooltip( "The speed at which the projectile moves." )]
        public float speed = 20.0f;

        [Tooltip( "The amount of time before the projectile stops." )]
        public float lifeSpan = 2.0f;

        // true if bullet is currently being shot or otherwise moving
        private bool active = false;

        // amount of time since projectile was fired
        private float timeSinceFired = 0.0f;

        // the point around which objects will rotate
        private Vector3 gravityCore;

        // Update is called once per frame
        void Update ()
        {
            if ( !active )
            {
                return;
            }

            timeSinceFired += Time.deltaTime;

            if ( timeSinceFired >= lifeSpan )
            {
                Destroy( gameObject );
                return;
            }

            transform.RotateAround(gravityCore, transform.forward, speed * Time.deltaTime);
            //transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        }

        // Shoot the projectile in this direction
        public void Shoot ( Vector3 startingPosition, Vector3 direction, Vector3 gravityCore )
        {
            transform.position = startingPosition;
            transform.forward = direction;
            this.gravityCore = gravityCore;
            active = true;
        }
    }
}
