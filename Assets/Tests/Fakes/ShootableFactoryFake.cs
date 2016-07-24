using SpaceGame.Interfaces;
using TestHelpers;

namespace SpaceGame.Tests.Fakes
{
    class ShootableFactoryFake : UFake, IShootableFactory
    {
        public IShootable CreatePlayerBullet () { return evaluateMethod<IShootable>("CreatePlayerBullet"); }
    }
}
