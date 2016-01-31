using UnityEngine;
using SpaceGame.Interfaces;
using System;

namespace SpaceGame.Tests.Fakes
{
    public class PhysicalFactoryFake : MonoBehaviour, IPhysicalFactory
    {
        // create enemy ship

        public int createEnemyShipCalled = 0;

        public PhysicalFake createEnemyShipReturns;

        public IPhysical CreateEnemyShip ()
        {
            createEnemyShipCalled++;
            return createEnemyShipReturns;
        }

        // create player ship

        public int createPlayerShipCalled = 0;

        public PhysicalFake createPlayerShipReturns;

        public IPhysical CreatePlayerShip ()
        {
            createPlayerShipCalled++;
            return createPlayerShipReturns;
        }

        public void ResetFake ()
        {
            createEnemyShipCalled = 0;
            createEnemyShipReturns = default(PhysicalFake);
            createPlayerShipCalled = 0;
            createPlayerShipReturns = default(PhysicalFake);
        }
    }
}
