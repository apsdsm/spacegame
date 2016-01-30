using UnityEngine;
using SpaceGame.Interfaces;

namespace SpaceGame.Tests.Fakes
{
    class ShootableFake : IShootable
    {
        public int shootCalled = 0;
        public Vector3 shootStartingPositionValue;
        public Vector3 shootDirectionValue;

        public void Shoot ( Vector3 startingPosition, Vector3 direction )
        {
            shootCalled++;
            shootStartingPositionValue = startingPosition;
            shootDirectionValue = direction;
        }
    }
}
