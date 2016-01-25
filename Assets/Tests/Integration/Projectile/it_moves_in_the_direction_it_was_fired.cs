using UnityEngine;

namespace SpaceGame.Tests.Integration.ProjectileTests
{

    [IntegrationTest.DynamicTest( "ProjectileTests" )]
    class it_moves_in_the_direction_it_was_fired : projectile_test
    {

        public override void SetUp ()
        {
            base.SetUp();

            projectile.speed = 10.0f;
            projectile.lifeSpan = 10.0f;
            projectile.Shoot( Vector3.zero, Vector3.forward );
        }

        void TestEachFrame ()
        {
            float distanceTravelled = ( projectile_object.transform.position ).magnitude;

            if ( distanceTravelled > 0.0f )
            {
                Pass();
            }
        }

    }
}

