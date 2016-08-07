using SpaceGame.Interfaces;
using TestHelpers;

namespace SpaceGame.Tests.Fakes
{
    public class PhysicalFactoryFake : UFake, IPhysicalFactory
    {
        public IPhysical CreateEnemyShip()
        { 
            return Evaluate<IPhysical>(Call("CreateEnemyShip"));
        }

        public IPhysical CreatePlayerShip()
        {
            return Evaluate<IPhysical>(Call("CreatePlayerShip"));
        }
    }
}
