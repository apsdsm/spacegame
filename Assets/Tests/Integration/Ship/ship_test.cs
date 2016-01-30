using UnityEngine;
using SpaceGame.Actors;
using Flexo;
using TestHelpers;

namespace SpaceGame.Tests.Integration.ShipTests
{
    class ship_test : UTestCase
    {
        protected GameObject ship_object;
        protected Ship ship;

        public override void SetUp ()
        {
            base.SetUp();

            ship_object = new FlexoGameObject( "player" ).With<Ship>( out ship );

        }

        public override void TearDown ()
        {
            base.TearDown();

            GameObject.Destroy( ship_object );
        }
    }
}
