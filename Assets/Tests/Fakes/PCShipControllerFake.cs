using UnityEngine;
using SpaceGame.Interfaces;

namespace SpaceGame.Tests.Fakes
{
    class PCShipControllerFake : MonoBehaviour, IShipController
    {
        public int registerCalled = 0;
        public int deregisterCalled = 0;

        public void Register ( IControllableShip ship )
        {
            registerCalled++;
        }

        public void Deregister ( IControllableShip ship )
        {
            deregisterCalled++;
        }
    }
}
