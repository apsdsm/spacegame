using SpaceGame.Interfaces;
using TestHelpers;

namespace SpaceGame.Tests.Fakes
{
    class PCShipControllerFake : UFake, IShipController
    {
        public void Register(IControllableShip ship)
        {
            Evaluate(Call("Register").With(ship)); 
        }

        public void Deregister(IControllableShip ship)
        { 
            Evaluate(Call("Deregister").With(ship)); 
        }
    }
}
