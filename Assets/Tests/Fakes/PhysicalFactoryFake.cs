using SpaceGame.Interfaces;
using TestHelpers;

namespace SpaceGame.Tests.Fakes
{
    public class PhysicalFactoryFake : UFake, IPhysicalFactory
    {
        public IPhysical CreateEnemyShip () { return evaluateMethod<IPhysical>("CreateEnemyShip"); }
        
        public IPhysical CreatePlayerShip () { return evaluateMethod<IPhysical>("CreatePlayerShip"); }
    }
}
