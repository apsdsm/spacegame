using SpaceGame.Interfaces;
using TestHelpers;

namespace SpaceGame.Tests.Fakes
{
    class PCShipControllerFake : UFake, IShipController
    {
        public void Register ( IControllableShip ship ) { evaluateMethod("Register", ship); }

        public void Deregister ( IControllableShip ship ) { evaluateMethod("Deregister", ship); }
    }
}
