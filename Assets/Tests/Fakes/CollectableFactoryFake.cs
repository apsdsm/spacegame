using SpaceGame.Interfaces;
using TestHelpers;

namespace SpaceGame.Tests.Fakes
{
    public class CollectableFactoryFake : UFake, ICollectableFactory
    {
        public ICollectable CreateCoin () { return evaluateMethod<ICollectable>("CreateCoin"); }
    }
}
