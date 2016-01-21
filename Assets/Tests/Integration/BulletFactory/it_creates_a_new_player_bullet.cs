using UnityEngine;
using SpaceGame.Interfaces;

namespace SpaceGame.Tests.Integration.BulletFactoryTests
{

    [IntegrationTest.DynamicTest( "BulletFactoryTests" )]
    class it_creates_a_new_player_bullet : bullet_factory_test
    {
        void Test ()
        {
            IShootable result =  bullet_factory.CreatePlayerBullet();

            AssertThat( result != null, "created object was null." );
        }
    }
}