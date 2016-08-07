using UnityEngine;
using SpaceGame.Interfaces;
using SpaceGame.Actors;

namespace SpaceGame.Factories
{

    public class ShootableFactory : MonoBehaviour, IShootableFactory
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
                IShootable component = gameObject.GetComponent<Projectile>();
                return component;
            }

            return null;
        }
    }
}