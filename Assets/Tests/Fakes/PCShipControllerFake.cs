using UnityEngine;
using SpaceGame.Interfaces;

namespace SpaceGame.Tests.Fakes
{
    class PCShipControllerFake : MonoBehaviour, IShipController
    {
        public int registerCalled = 0;
        public int deregisterCalled = 0;

        public void Register ( IControllable ship )
        {
            registerCalled++;
        }

        public void Deregister ( IControllable ship )
        {
            deregisterCalled++;
        }
    }
}
