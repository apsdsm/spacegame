﻿using System;
using UnityEngine;
using SpaceGame.Interfaces;
using SpaceGame.Actors;
using SpaceGame.Agents;
using Fletch;

namespace SpaceGame.Factories
{

    public class ShootableFactory : MonoBehaviour, IBulletFactory
    {
        [Tooltip( "The bullet prefab spawned for the player." )]
        public GameObject playerBullet;

        /// <summary>
        /// Instantiate and return a Bullet object.
        /// </summary>
        /// <returns></returns>
        public IShootable CreatePlayerBullet ()
        {
            if ( playerBullet != null )
            {
                GameObject gameObject = Instantiate( playerBullet );
                IShootable shootable = gameObject.GetComponent<Projectile>();

                return shootable;
            }

            return null;
        }
    }
}