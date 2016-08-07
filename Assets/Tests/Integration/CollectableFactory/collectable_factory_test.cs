using UnityEngine;
using SpaceGame.Factories;
using TestHelpers;

namespace SpaceGame.Tests.Integration.CollectableFactoryTests
{

    class collectable_factory_test : UTestCase
    {
        // sut
        protected CollectableFactory collectable_factory;
        protected GameObject collectable_factory_object;

        /// <summary>
        /// Set up new ship object.
        /// </summary>
        override public void SetUp ()
        {
            collectable_factory_object = GameObject.Find( "CollectableFactory" );
            collectable_factory = collectable_factory_object.GetComponent<CollectableFactory>();
        }
    }
}
