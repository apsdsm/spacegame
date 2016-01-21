using UnityEngine;
using SpaceGame.Factories;
using TestHelpers;

namespace SpaceGame.Tests.Integration.ShipFactoryTests
{

    class ship_factory_test : UTestCase
    {
        // sut
        protected ShipFactory ship_factory;

        // game object
        protected GameObject ship_factory_object;

        /// <summary>
        /// Set up new ship object.
        /// </summary>
        override public void SetUp ()
        {
            ship_factory_object = GameObject.Find( "ShipFactory" );
            ship_factory = ship_factory_object.GetComponent<ShipFactory>();
        }
    }
}
