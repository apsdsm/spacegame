using UnityEngine;
using SpaceGame.Actors;
using Flexo;
using TestHelpers;

namespace SpaceGame.Tests.Integration.ProjectileTests
{
    class projectile_test : UTestCase
    {
        protected GameObject projectile_object;
        protected Projectile projectile;

        public override void SetUp ()
        {
            base.SetUp();

            projectile_object = new FlexoGameObject( "projectile" ).With<Projectile>( out projectile );

        }

        public override void TearDown ()
        {
            base.TearDown();

            GameObject.Destroy( projectile_object );
        }
    }
}
