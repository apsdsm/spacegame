using UnityEngine;
using SpaceGame.Factories;
using TestHelpers;

namespace SpaceGame.Tests.Integration.BulletFactoryTests
{

    class shootable_factory_test : UTestCase
    {
        // system under test
        protected ShootableFactory bullet_factory;

        // game object
        protected GameObject bullet_factory_object;

        /// <summary>
        /// Set up new ship object.
        /// </summary>
        override public void SetUp ()
        {
            bullet_factory_object = GameObject.Find( "BulletFactory" );
            bullet_factory = bullet_factory_object.GetComponent<ShootableFactory>();
        }
    }
}
