using UnityEngine;
using SpaceGame.Tests.Fakes;
using SpaceGame.Interfaces;
using Fletch;
using TestHelpers;

namespace SpaceGame.Tests.Integration.ShipTests
{
    [IntegrationTest.DynamicTest( "ShipTests" )]
    class it_shoots_a_projectile : ship_test
    {
        ShootableFactoryFake factory;

        public override void SetUp ()
        {
            base.SetUp();

            factory = (ShootableFactoryFake)IOC.Resolve<IShootableFactory>();
            factory.createPlayerBulletCalled = 0;

        }

        void Test ()
        {
            ship.Shoot();

            AssertThat( factory.createPlayerBulletCalled == 1 );
            AssertThat( factory.shootableFake.shootCalled == 1 );
            AssertThat( factory.shootableFake.shootDirectionValue == ship_object.transform.forward );
            AssertThat( factory.shootableFake.shootStartingPositionValue == ship_object.transform.position );
        }
    }
}

