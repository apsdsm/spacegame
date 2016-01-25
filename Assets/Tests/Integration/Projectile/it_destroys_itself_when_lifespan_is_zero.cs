using UnityEngine;

namespace SpaceGame.Tests.Integration.ProjectileTests
{

    [IntegrationTest.DynamicTest( "ProjectileTests" )]
    class it_destroys_itself_when_lifespan_is_zero : projectile_test
    {

        public override void SetUp ()
        {
            base.SetUp();

            projectile.speed = 10.0f;
            projectile.lifeSpan = 0.5f;
            projectile.Shoot( Vector3.zero, Vector3.forward );
        }

        void TestEachFrame ()
        {
            if ( TotalTime > 0.5f )
            {
                AssertThat( projectile_object == null );
            }
        }
    }
}

