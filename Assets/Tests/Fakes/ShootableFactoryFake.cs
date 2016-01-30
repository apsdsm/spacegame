using UnityEngine;
using SpaceGame.Interfaces;
using System;

namespace SpaceGame.Tests.Fakes
{
    class ShootableFactoryFake : MonoBehaviour, IShootableFactory
    {
        public int createPlayerBulletCalled = 0;
        public ShootableFake shootableFake;

        public IShootable CreatePlayerBullet ()
        {
            createPlayerBulletCalled++;
            shootableFake = new ShootableFake();
            return shootableFake;
        }
    }
}
